// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RottenTomatoXamarin
{
	[Register ("MovieCell")]
	partial class MovieCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AudienceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CriticsScoreLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView FlixsterImg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView PosterImg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView TomatoImg { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AudienceLabel != null) {
				AudienceLabel.Dispose ();
				AudienceLabel = null;
			}
			if (CriticsScoreLabel != null) {
				CriticsScoreLabel.Dispose ();
				CriticsScoreLabel = null;
			}
			if (FlixsterImg != null) {
				FlixsterImg.Dispose ();
				FlixsterImg = null;
			}
			if (PosterImg != null) {
				PosterImg.Dispose ();
				PosterImg = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
			if (TomatoImg != null) {
				TomatoImg.Dispose ();
				TomatoImg = null;
			}
		}
	}
}
