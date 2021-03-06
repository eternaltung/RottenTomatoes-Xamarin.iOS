using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net.Http;
using RottenTomatoXamarin.Model;
using Newtonsoft.Json;
using RottenTomatoXamarin.Controller;
using System.Threading.Tasks;
using System.Collections.Generic;
using CoreGraphics;
using MBProgressHUD;
using Reachability;
using ObjCRuntime;

namespace RottenTomatoXamarin
{
	partial class MovieViewController : UIViewController
	{
		string apikey = "";

		public MovieViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			this.TabBarController.Title = this.TabBarItem.Title == "Movie" ? "Box Office" : "DVD Top Rentals";
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Reachability.Reachability.ReachabilityChanged+= Reachability_Reachability_ReachabilityChanged;

			//check network
			if (Reachability.Reachability.InternetConnectionStatus() == NetworkStatus.NotReachable) {
				addErrorView ();
				return;
			}
			AddRefreshControl();
			await ReloadMovieTable();
		}

		private async Task ReloadMovieTable()
		{
			string url = this.TabBarItem.Title == "Movie" ? $"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey={apikey}&limit=20" 
				: $"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?apikey={apikey}&limit=20";
			
			var hud = new MTMBProgressHUD (View) {
				LabelText = "Loading...",
				RemoveFromSuperViewOnHide = true
			};
			View.AddSubview (hud);
			hud.Show (true);

			List<Movie> movies = await Utility.GetMovieData (url);
			this.MovieTable.Source = new MovieTableController(movies, this);

			this.MovieTable.ReloadData ();
			SearchCollectionView searchview = (SearchCollectionView)this.TabBarController.ViewControllers [2];
			searchview.allData = movies;
			hud.Hide (true);
		}

		void Reachability_Reachability_ReachabilityChanged (object sender, EventArgs e)
		{
			if (Reachability.Reachability.InternetConnectionStatus () == NetworkStatus.NotReachable) {
				addErrorView ();
			} 
			else {
				this.MovieTable.TableHeaderView = null;
			}
		}

		private void AddRefreshControl()
		{
			UIRefreshControl refreshControl = new UIRefreshControl(){
				AttributedTitle = new NSAttributedString("pull to refresh")
			};
			refreshControl.ValueChanged += RefreshControl_ValueChanged;
			MovieTable.AddSubview(refreshControl);
		}

		async void RefreshControl_ValueChanged (object sender, EventArgs e)
		{
			(sender as UIRefreshControl).AttributedTitle = new NSAttributedString("loading...");
			this.MovieTable.Source = null;
			await ReloadMovieTable();
			(sender as UIRefreshControl).EndRefreshing();
		}

		/// <summary>
		/// Adds the error view.
		/// </summary>
		private void addErrorView()
		{
			UIView errorView = new UIView (new CGRect (0, 0, View.Bounds.Width, 30)) {
				BackgroundColor = UIColor.Yellow
			};
			UILabel errorLabel = new UILabel (new CGRect (0, 0, View.Bounds.Width, 30)) { 
				TextAlignment = UITextAlignment.Center,
				Text = "⚠️      Network error"
			};
			errorView.AddSubview (errorLabel);
			this.MovieTable.TableHeaderView = errorView;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
