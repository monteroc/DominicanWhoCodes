using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DominicanWhoCodes.Controls
{
    public partial class RoundInitialsView : ContentView
    {
        public string NameInitials
        {
            get { return (string)GetValue(NameInitialsProperty); }
            set { SetValue(NameInitialsProperty, value); }
        }

        public static readonly BindableProperty NameInitialsProperty =
            BindableProperty.Create("NameInitials", typeof(string), typeof(RoundInitialsView), string.Empty, propertyChanged: OnNameInitialsChanged);


        public RoundInitialsView()
        {
            InitializeComponent();
        }

        private static void OnNameInitialsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RoundInitialsView)bindable;

            if (newValue != null)
                control.initialsText.Text = (string)newValue;
        }
    }
}
