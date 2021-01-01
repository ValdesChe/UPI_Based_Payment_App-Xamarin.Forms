using System;
using UPIBasedPaymentApp.Extensions;
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

        internal void ResetToHomePage()
        {
            CurrentPage = homePage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnCurrentPageChanged()
        {
            if (CurrentPage is HomePage homePage)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, true);
                NavigationPage.SetHasBackButton(this, true);
            }
        }
    }
}
