using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views.InputMethods;
using DominicanWhoCodes.Controls;
using DominicanWhoCodes.Droid.Renderers;
using DominicanWhoCodes.Modules.Developers.Views;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DevelopersPage), typeof(SearchPageRenderer))]
namespace DominicanWhoCodes.Droid.Renderers
{
    public class SearchPageRenderer : PageRenderer
    {
        public SearchPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Element is ISearchPage && Element is Page page && page.Parent is NavigationPage navigationPage)
            {
                //Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
                navigationPage.Popped += HandleNavigationPagePopped;
                navigationPage.PoppedToRoot += HandleNavigationPagePopped;
            }
        }

        //Adding the SearchBar in OnSizeChanged ensures the SearchBar is re-added after the device is rotated, because Xamarin.Forms automatically removes it
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            if (Element is ISearchPage && Element is Page page)
            {
                AddSearchToToolbar(page.Title);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (GetToolbar() is Toolbar toolBar)
                toolBar.Menu?.RemoveItem(Resource.Menu.MainMenu);

            base.Dispose(disposing);
        }

        //Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
        void HandleNavigationPagePopped(object sender, NavigationEventArgs e)
        {
            if (sender is NavigationPage navigationPage
                && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar(navigationPage.CurrentPage.Title);
            }
        }

        void AddSearchToToolbar(string pageTitle)
        {
            if (GetToolbar() is Toolbar toolBar
                && toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>().GetType() != typeof(SearchView))
            {
                toolBar.Title = pageTitle;
                toolBar.InflateMenu(Resource.Menu.MainMenu);

                var searchView = toolBar.Menu?.FindItem(Resource.Id.ActionSearch)?.ActionView?.JavaCast<SearchView>() as SearchView;
                if (searchView != null)
                {
                    RegisterSearchViewEvent(searchView);
                    ConfigureSearchView(searchView);
                    SetSearchViewAppearance(searchView);
                }
            }
        }

        private void RegisterSearchViewEvent(SearchView searchView)
        {
            searchView.QueryTextChange += HandleQueryTextChange;
        }

        private static void ConfigureSearchView(SearchView searchView)
        {
            searchView.ImeOptions = (int)ImeAction.Search;
            searchView.InputType = (int)InputTypes.TextVariationFilter;
            searchView.SetIconifiedByDefault(false);
        }

        private static void SetSearchViewAppearance(SearchView searchView)
        {
            searchView.SetBackgroundResource(Resource.Drawable.round_searchview);

            var _closeBtn = searchView.FindViewById<Android.Widget.ImageView>(Resource.Id.search_close_btn);
            _closeBtn.SetColorFilter(Color.Black.ToAndroid());

            var _searchBtn = searchView.FindViewById<Android.Widget.ImageView>(Resource.Id.search_mag_icon);
            _searchBtn.SetColorFilter(Color.Black.ToAndroid());
        }

        private void HandleQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (Element is ISearchPage searchPage)
                searchPage.OnSearchBarTextChanged(e.NewText);
        }

        Toolbar GetToolbar() => CrossCurrentActivity.Current.Activity.FindViewById<Toolbar>(Resource.Id.toolbar);
    }
}
