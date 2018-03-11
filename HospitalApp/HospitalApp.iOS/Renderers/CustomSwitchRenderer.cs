using HospitalApp.CustomControls;
using HospitalApp.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomToggled), typeof(CustomSwitchRenderer))]
namespace HospitalApp.iOS.Renderers
{
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    public class CustomSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UISwitch here!
                Control.OnTintColor = UIColor.FromHSBA(0.01f, 0.77f, 0.89f, 1.00f);
            }
        }
    }
}