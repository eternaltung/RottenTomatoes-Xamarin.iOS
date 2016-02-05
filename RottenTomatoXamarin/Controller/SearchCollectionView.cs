using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;
using System.Collections.ObjectModel;
using RottenTomatoXamarin.Model;
using System.Collections.Generic;
using System.Linq;

namespace RottenTomatoXamarin
{
	public partial class SearchCollectionView : UICollectionViewController
	{
		string identifer = "MovieCell";
		public List<Movie> filterData = new List<Movie>();
		public List<Movie> allData = new List<Movie>();
		UISearchBar searchbar;

		public override void ViewDidAppear (bool animated)
		{
			if (searchbar != null && searchbar.Text != string.Empty) 
			{
				return;
			}
			filterData = allData;
			this.TabBarController.Title = "Search";
			this.CollectionView.ReloadData ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			UINib nib = UINib.FromName ("SearchCollectionCell", null);
			this.CollectionView.RegisterNibForCell (nib, identifer);
			AddSearchBar ();
		}

		public SearchCollectionView (IntPtr handle) : base (handle)
		{
			
		}

		/// <summary>
		/// Adds the search bar.
		/// </summary>
		private void AddSearchBar()
		{
			var height = this.NavigationController.NavigationBar.Frame.Height + UIApplication.SharedApplication.StatusBarFrame.Height;
			searchbar = new UISearchBar (new CGRect (0, height, this.CollectionView.Frame.Size.Width, 40))
			{
				Placeholder = "search",
				ShowsCancelButton = true,
				Delegate = new SearchDelegate(this)
			};
			this.View.AddSubview (searchbar);
		}

		#region collection override method
		public override nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return filterData.Count;
			//return base.GetItemsCount (collectionView, section);
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			SearchCollectionCell cell = (SearchCollectionCell)collectionView.DequeueReusableCell (identifer, indexPath);
			cell.movie = filterData [indexPath.Row];
			cell.UpdateCell ();
			return cell;
		}

		public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			DetailViewController view = this.NavigationController.Storyboard.InstantiateViewController ("DetailView") as DetailViewController;
			view.movie = filterData [indexPath.Row];
			this.NavigationController.PushViewController (view ,true);
		}

		public override nint NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		public override bool ShouldSelectItem (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}

		[Export ("collectionView:layout:insetForSectionAtIndex:")]
		public virtual UIEdgeInsets GetInsetForSection (UICollectionView collectionView, UICollectionViewLayout layout, int section)
		{
			return new UIEdgeInsets (5, 5, 5, 5);
		}
		#endregion

	}

	/// <summary>
	/// Search delegate.
	/// </summary>
	public class SearchDelegate : UISearchBarDelegate
	{
		private SearchCollectionView searchView;

		public SearchDelegate(SearchCollectionView view)
		{
			searchView = view;
		}

		public override void SearchButtonClicked (UISearchBar searchBar)
		{
			searchBar.ResignFirstResponder ();
		}

		public override void CancelButtonClicked (UISearchBar searchBar)
		{
			searchBar.Text = "";
			searchView.filterData = searchView.allData;
			searchView.CollectionView.ReloadData ();
			searchBar.ResignFirstResponder ();
		}

		public override void TextChanged (UISearchBar searchBar, string searchText)
		{
			searchView.filterData = searchView.allData.Where (x => x.title.ToLower ().StartsWith (searchBar.Text.ToLower ())).ToList();
			searchView.CollectionView.ReloadData ();
		}
	}

	/*public class CustomViewDelegate : UICollectionViewDelegateFlowLayout
	{
		public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			string a = "1";
		}

		public override UIEdgeInsets GetInsetForSection (UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return new UIEdgeInsets (5, 5, 5, 5);
		}

		public override CGSize GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			return new CGSize (170, 220);
		}

		public override bool ShouldSelectItem (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}
	}*/

}
