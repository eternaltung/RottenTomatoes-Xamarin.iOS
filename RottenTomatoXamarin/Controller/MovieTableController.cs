using System;
using System.Collections.Generic;
using UIKit;
using RottenTomatoXamarin.Model;
using Foundation;

namespace RottenTomatoXamarin.Controller
{
	public class MovieTableController : UITableViewSource
	{
		private List<Movie> data;
		NSString cellIdentifier = new NSString("Cell");
		UIViewController parent;

		public MovieTableController (List<Movie> movies, UIViewController viewController)
		{
			data = movies;
			this.parent = viewController;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			MovieCell cell = tableView.DequeueReusableCell (cellIdentifier) as MovieCell;
			Movie movie = data[indexPath.Row];

			if (cell == null)
			{
				cell = new MovieCell();
			}
			cell.UpdateCell (movie);
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return data.Count;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//UIStoryboard sb = UIStoryboard.FromName("Main",null);
			DetailViewController view = parent.NavigationController.Storyboard.InstantiateViewController ("DetailView") as DetailViewController;
			view.movie = data [indexPath.Row];
			tableView.DeselectRow (indexPath, true);
			parent.NavigationController.PushViewController (view ,true);
		}
	}
}

