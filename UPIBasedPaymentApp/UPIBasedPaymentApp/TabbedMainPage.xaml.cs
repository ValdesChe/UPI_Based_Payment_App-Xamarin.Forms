using UPIBasedPaymentApp.Views.Page;
using Xamarin.Forms;

namespace UPIBasedPaymentApp
{

    public partial class TabbedMainPage : TabbedPage
    {

        public TabbedMainPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this,
                    Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
