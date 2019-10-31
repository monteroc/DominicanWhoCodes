using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace DominicanWhoCodes.Modules.Developers.Controls
{
    public partial class SocialIcon : ContentView
    {
        public ICommand Command
        {
            get => socialImage.Command;
            set => socialImage.Command = value;
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(SocialIcon),
                defaultValue: null,
                propertyChanged: CommandPropertyChanged);

        public object CommandParameter
        {
            get => socialImage.CommandParameter;
            set => socialImage.CommandParameter = value;
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                propertyName: "CommandParameter",
                returnType: typeof(object),
                declaringType: typeof(SocialIcon),
                defaultValue: null,
                propertyChanged: CommandParameterPropertyChanged);


        public ImageSource SocialImageSource
        {
            get { return (string)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public static readonly BindableProperty BackgroundImageProperty =
            BindableProperty.Create("SocialImageSource", typeof(ImageSource), typeof(SocialIcon), null, propertyChanged: OnSocialImageSourceChanged);

        public SocialIcon()
        {
            InitializeComponent();
        }

        internal static void CommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SocialIcon)bindable;

            control.socialImage.Command = (ICommand)newValue;
        }

        internal static void CommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SocialIcon)bindable;

            control.socialImage.CommandParameter = newValue;
        }

        private static void OnSocialImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SocialIcon)bindable;

            if (newValue != null)
                control.socialImage.Source = (ImageSource)newValue;
        }
    }
}
