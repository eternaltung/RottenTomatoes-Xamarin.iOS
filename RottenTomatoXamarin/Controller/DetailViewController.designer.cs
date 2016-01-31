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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView BackgroundImg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView DetailTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BackgroundImg != null) {
				BackgroundImg.Dispose ();
				BackgroundImg = null;
			}
			if (DetailTextView != null) {
				DetailTextView.Dispose ();
				DetailTextView = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
