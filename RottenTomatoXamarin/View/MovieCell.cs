using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RottenTomatoXamarin.Model;
using System.Threading.Tasks;
using System.Net.Http;

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

		public async void UpdateCell(Movie movie)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Default;
			TitleLabel.Text = movie.title;
			CriticsScoreLabel.Text = movie.ratings.critics_score.ToString();
			PosterImg.Image = null;
			PosterImg.Image = await LoadImage (movie.posters.thumbnail);
			PosterImg.Alpha = 0;
			UIView.Animate (0.8, () => 
			{
					PosterImg.Alpha = 1;
			});
			AudienceLabel.Text = movie.ratings.audience_score.ToString();

		}

		public async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();
			var contents = await httpClient.GetByteArrayAsync (imageUrl);
			return UIImage.LoadFromData (NSData.FromArray (contents));
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
