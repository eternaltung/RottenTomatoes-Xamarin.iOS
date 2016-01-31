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

namespace RottenTomatoXamarin
{
	partial class MovieViewController : UIViewController
	{
		string apikey = "";

		public MovieViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			if (this.TabBarItem.Title == "Movie")
			{
				this.TabBarController.Title = "Box Office";
			}
			else
			{
				this.TabBarController.Title = "DVD Top Rentals";
			}

			Reachability.Reachability.ReachabilityChanged+= Reachability_Reachability_ReachabilityChanged;

			//check network
			if (Reachability.Reachability.InternetConnectionStatus() == NetworkStatus.NotReachable) {
				addErrorView ();
				return;
			}

			var hud = new MTMBProgressHUD (View) {
				LabelText = "Loading...",
				RemoveFromSuperViewOnHide = true
			};
			View.AddSubview (hud);
			hud.Show (true);

			//CGRect rect = new CGRect (0, 0, View.Bounds.Width, View.Bounds.Height);
			//UITableView movieTable = new UITableView(rect);
			//View.AddSubview (movieTable);

			//this.MovieTable = new UITableView (View.Bounds);
			List<Movie> movies = await GetMovieData ();
			this.MovieTable.Source = new MovieTableController(movies, this);

			this.MovieTable.ReloadData ();
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

		public async Task<List<Movie>> GetMovieData()
		{
			HttpClient client = new HttpClient();
			string url = string.Format("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey={0}",apikey);
			string json = await client.GetStringAsync(new Uri(url, UriKind.Absolute));
			MovieModel model = JsonConvert.DeserializeObject<MovieModel>(json);
			return model.movies;
		}
	}
}
