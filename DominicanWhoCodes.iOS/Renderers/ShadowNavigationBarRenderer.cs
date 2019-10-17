using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using DominicanWhoCodes.iOS.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ShadowNavigationBarRenderer))]
namespace DominicanWhoCodes.iOS.Renderers
{
    public class ShadowNavigationBarRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (this.Element == null) return;

            NavigationBar.Layer.ShadowColor = UIColor.Gray.CGColor;
            NavigationBar.Layer.ShadowOffset = new CGSize(0, 2);
            NavigationBar.Layer.ShadowOpacity = 1;
        }
    }
}
