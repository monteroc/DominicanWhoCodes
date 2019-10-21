using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using DominicanWhoCodes.Modules.Developers.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.Views
{
    public partial class DevelopersPage : ReactiveContentPage<DevelopersViewModel>
    {
        public DevelopersPage()
        {
            InitializeComponent();

            this.WhenActivated(
                disposables =>
                {
                    this.OneWayBind(this.ViewModel,
                       x => x.Developers,
                       x => x.developersList.ItemsSource)
                    .DisposeWith(disposables);

                    this.OneWayBind(this.ViewModel,
                       x => x.Title,
                       x => x.navTitle.NavigationTitle)
                    .DisposeWith(disposables);

                    this.Bind(this.ViewModel,
                      x => x.SelectedDeveloper,
                      x => x.developersList.SelectedItem)
                   .DisposeWith(disposables);

                });
        }      

        protected override void OnAppearing()
        {
            ViewModel.UpdateStatusbar();         
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // This is to avoid the orange on selected background color on android
            if (e.SelectedItem == null) return;

            ((ListView)sender).SelectedItem = null;
        }
    }
}
