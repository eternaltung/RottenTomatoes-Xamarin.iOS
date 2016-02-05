using System;

using Foundation;
using UIKit;
using RottenTomatoXamarin.Model;

namespace RottenTomatoXamarin
{
	public partial class SearchCollectionCell : UICollectionViewCell
	{
		//public static readonly NSString Key = new NSString ("SearchCollectionCell");
		//public static readonly UINib Nib;
		public Movie movie;

		static SearchCollectionCell ()
		{
			//Nib = UINib.FromName ("SearchCollectionCell", NSBundle.MainBundle);
		}

		public SearchCollectionCell (IntPtr handle) : base (handle)
		{
		}

		/// <summary>
		/// Updates the cell.
		/// </summary>
		public async void UpdateCell()
		{
			TitleLabel.Text = movie.title;
			PosterImg.Image = null;
			PosterImg.Image = await Utility.LoadImage(movie.posters.thumbnail);
			PosterImg.Alpha = 0;
			UIView.Animate (0.8, () => 
				{
					PosterImg.Alpha = 1;
				});
		}
	}
}
