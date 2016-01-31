using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using RottenTomatoXamarin.Model;
using CoreGraphics;
using ObjCRuntime;

namespace RottenTomatoXamarin
{
	partial class DetailViewController : UIViewController
	{
		public Movie movie { set; get; }

		public DetailViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			SetLayout ();
		}

		private async void SetLayout()
		{
			TitleLabel.Text = $"{movie.title}({movie.year}) {movie.runtime}mins";
			this.Title = movie.title;
			AddDescLabel (movie.synopsis);
			addGesture ();
			BackgroundImg.Image = await Utility.LoadImage(movie.posters.thumbnail);
			BackgroundImg.Image = await Utility.LoadImage (convertToHighResolutionImg (movie.posters.thumbnail));
		}

		/// <summary>
		/// Converts to high resolution image.
		/// </summary>
		/// <returns>url</returns>
		/// <param name="url">URL.</param>
		private string convertToHighResolutionImg(string url)
		{
			return "https://content6.flixster.com/" + url.Substring(url.IndexOf("cloudfront.net/") + "cloudfront.net/".Length);
		} 

		/// <summary>
		/// Adds the description label.
		/// </summary>
		/// <param name="text">Text.</param>
		private void AddDescLabel(string text)
		{
			UILabel label = new UILabel (new CGRect (TitleLabel.Frame.X, TitleLabel.Frame.Bottom + 15, TitleLabel.Frame.Size.Width, HeightForLabel (TitleLabel, text))) {
				TextColor = UIColor.White,
				Text = text,
				Lines = 0
			};
			DetailTextView.AddSubview (label);
		}

		/// <summary>
		/// calculate heights for label.
		/// </summary>
		/// <returns>height</returns>
		/// <param name="label">Label.</param>
		/// <param name="text">Text.</param>
		private float HeightForLabel(UILabel label, string text)
		{
			CGRect rect = ((NSString)text).GetBoundingRect (new CGSize (label.Frame.Size.Width, float.MaxValue), 
				NSStringDrawingOptions.UsesLineFragmentOrigin, 
				new UIStringAttributes (){ Font = label.Font }, 
				null);
			return (float)rect.Size.Height;
		}

		/// <summary>
		/// Adds the gesture.
		/// </summary>
		private void addGesture()
		{
			UISwipeGestureRecognizer swipe = new UISwipeGestureRecognizer (this, new Selector ("HandleSwipe:")) {
				Direction = UISwipeGestureRecognizerDirection.Up
			};
			DetailTextView.AddGestureRecognizer (swipe);
			swipe = new UISwipeGestureRecognizer (this, new Selector ("HandleSwipe:")) {
				Direction = UISwipeGestureRecognizerDirection.Down
			};
			DetailTextView.AddGestureRecognizer (swipe);
		}

		/// <summary>
		/// Handles the swipe.
		/// </summary>
		/// <param name="sender">Sender.</param>
		[Export("HandleSwipe:")]
		private void HandleSwipe(UISwipeGestureRecognizer sender)
		{
			Double duration = 0.3;
			CGRect frame = DetailTextView.Frame;
			switch (sender.Direction) 
			{
			case UISwipeGestureRecognizerDirection.Up:
				UIView.BeginAnimations (null);
				UIView.SetAnimationDuration (duration);
				DetailTextView.Frame = new CGRect (0, frame.Y - 200, frame.Size.Width, frame.Size.Height);
				UIView.CommitAnimations ();
				break;
			case UISwipeGestureRecognizerDirection.Down:
				UIView.BeginAnimations (null);
				UIView.SetAnimationDuration (duration);
				DetailTextView.Frame = new CGRect (0, frame.Y + 200, frame.Size.Width, frame.Size.Height);
				UIView.CommitAnimations ();
				break;
			}
		}
	}
}
