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
	[Register ("MovieViewController")]
	partial class MovieViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView MovieTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MovieTable != null) {
				MovieTable.Dispose ();
				MovieTable = null;
			}
		}
	}
}
