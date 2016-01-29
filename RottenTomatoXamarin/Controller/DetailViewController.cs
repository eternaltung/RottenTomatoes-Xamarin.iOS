using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RottenTomatoXamarin.Model;

namespace RottenTomatoXamarin
{
	partial class DetailViewController : UIViewController
	{
		public Movie movie { set; get; }

		public DetailViewController (IntPtr handle) : base (handle)
		{
			
		}

		public DetailViewController ()
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TestLabel.Text = movie.title;
		}
	}
}
