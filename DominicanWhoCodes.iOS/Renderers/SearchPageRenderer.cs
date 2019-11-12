using System;
using DominicanWhoCodes.Controls;
using DominicanWhoCodes.iOS.Renderers;
using DominicanWhoCodes.Modules.Developers.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DevelopersPage), typeof(SearchPageRenderer))]
namespace DominicanWhoCodes.iOS.Renderers
{
    public class SearchPageRenderer : PageRenderer, IUISearchResultsUpdating
    {
        readonly UISearchController _searchController;

        public SearchPageRenderer()
        {
            _searchController = new UISearchController(searchResultsController: null)
            {
                SearchResultsUpdater = this,
                DimsBackgroundDuringPresentation = false,
                HidesNavigationBarDuringPresentation = false,
                HidesBottomBarWhenPushed = true
            };
            _searchController.SearchBar.Placeholder = string.Empty;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (ParentViewController.NavigationItem.SearchController is null)
            {
                ParentViewController.NavigationItem.SearchController = _searchController;
                DefinesPresentationContext = true;
                ParentViewController.NavigationItem.SearchController.Active = true;
                ParentViewController.NavigationItem.SearchController.Active = false;
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ParentViewController.NavigationItem.SearchController = null;
        }

        public void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            if (Element is ISearchPage searchPage)
                searchPage.OnSearchBarTextChanged(searchController.SearchBar.Text);
        }
    }
}
