using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using DominicanWhoCodes.Modules.Developers.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.Views
{
    public partial class DeveloperDetailsPage : ReactiveContentPage<DeveloperDetailsViewModel>
    {
        public DeveloperDetailsPage()
        {
            InitializeComponent();

            this.WhenActivated(
               disposables =>
               {
                   this.BindCommand(this.ViewModel,
                                    vm => vm.BackButtonCommand,
                                    v => v.backBtn
                                    )
                   .DisposeWith(disposables);

                   this.BindCommand(this.ViewModel,
                                    vm => vm.NavigateToSocialUrlCommand,
                                    v => v.gitImage)
                   .DisposeWith(disposables);

                   this.BindCommand(this.ViewModel,
                                    vm => vm.NavigateToSocialUrlCommand,
                                    v => v.twitterImage)
                   .DisposeWith(disposables);

                   this.BindCommand(this.ViewModel,
                                    vm => vm.NavigateToSocialUrlCommand,
                                    v => v.webImage)
                   .DisposeWith(disposables);

                   this.BindCommand(this.ViewModel,
                                    vm => vm.NavigateToSocialUrlCommand,
                                    v => v.linkedinImage)
                   .DisposeWith(disposables);

               });
        }
    }
}
