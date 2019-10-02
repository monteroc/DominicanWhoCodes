using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DominicanWhoCodes.Base;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.ViewModels
{
    public class DevelopersViewModel : BaseViewModel
    {
        private string _welcomeText;
        public string WelcomeText
        {
            get => _welcomeText;
            set => this.RaiseAndSetIfChanged(ref _welcomeText, value);
        }

        public DevelopersViewModel()
        {
            SayHelloFromReactive();
        }

        public void SayHelloFromReactive()
        {
            WelcomeText = "Hi, welcome to ReactiveUI";
        }
    }
}

