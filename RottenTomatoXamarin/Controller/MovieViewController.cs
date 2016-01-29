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

namespace RottenTomatoXamarin
{
	partial class MovieViewController : UIViewController
	{
		string apikey = "dagqdghwaq3e3mxyrp7kmmj5";

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

			//CGRect rect = new CGRect (0, 0, View.Bounds.Width, View.Bounds.Height);
			//UITableView movieTable = new UITableView(rect);
			//View.AddSubview (movieTable);

			//this.MovieTable = new UITableView (View.Bounds);
			List<Movie> movies = await GetMovieData ();
			this.MovieTable.Source = new MovieTableController(movies, this);
			//movieTable.Source = new MovieTableController(movies);

			this.MovieTable.ReloadData ();
			// Perform any additional setup after loading the view, typically from a nib.
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
