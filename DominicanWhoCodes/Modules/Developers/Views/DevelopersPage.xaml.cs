using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using DominicanWhoCodes.Modules.Developers.ViewModels;
using ReactiveUI;
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
                           x => x.WelcomeText,
                           x => x.welcomeLbl.Text)
                    .DisposeWith(disposables);

                });           
        }
    }
}
