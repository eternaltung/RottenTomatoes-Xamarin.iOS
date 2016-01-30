using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RottenTomatoXamarin.Model;

namespace RottenTomatoXamarin
{
	partial class MovieCell : UITableViewCell
	{
		public MovieCell (IntPtr handle) : base (handle)
		{
		}

		public MovieCell():base()
		{
		}

		public void UpdateCell(Movie movie)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Default;
			TitleLabel.Text = movie.title;
			CriticsScoreLabel.Text = movie.ratings.critics_score.ToString();
		}

		public override void SetSelected (bool selected, bool animated)
		{
			base.SetSelected (selected, animated);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
		}
	}
}
