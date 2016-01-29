using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RottenTomatoXamarin.Model;
using CoreGraphics;

namespace RottenTomatoXamarin
{
	partial class MovieCell : UITableViewCell
	{
		UILabel NameLabel;

		public MovieCell (IntPtr handle) : base (handle)
		{
			
		}

		public MovieCell()
		{
		}

		public void UpdateCell(Movie movie)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.FromRGB (218, 255, 127);
			NameLabel = new UILabel () {
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.Red
			};
			NameLabel.Text = movie.title;
			ContentView.Add (NameLabel);
			//ContentView.AddSubviews (new UIView[]{ NameLabel });
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			NameLabel.Frame = new CGRect (5, 4, ContentView.Bounds.Width, 25);
		}

		public override void SetSelected (bool selected, bool animated)
		{
			base.SetSelected (selected, animated);
		}
	}
}
