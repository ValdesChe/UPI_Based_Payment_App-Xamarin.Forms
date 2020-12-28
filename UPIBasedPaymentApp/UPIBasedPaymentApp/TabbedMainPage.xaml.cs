using UPIBasedPaymentApp.Views.Page;
using Xamarin.Forms;

namespace UPIBasedPaymentApp
{

    public partial class TabbedMainPage : TabbedPage
    {
        private NavigationPage _notificationPage;
        private NavigationPage _homePage;

        public TabbedMainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            _notificationPage = new NavigationPage(new NotificationPage())
            {
                Title = "Notification",
                IconImageSource = ImageSource.FromResource("UPIBasedPaymentApp.Resources.Icons.notification.png")
            };
            Children.Add(_notificationPage);

            _homePage = new NavigationPage(new HomePage())
            {
                Title = "Home",
                IconImageSource = ImageSource.FromResource("UPIBasedPaymentApp.Resources.Icons.home.png")
            };
            Children.Add(_homePage);

            var settingsPage = new NavigationPage(new SettingPage())
            {
                Title = "Setting",
                IconImageSource = ImageSource.FromResource("UPIBasedPaymentApp.Resources.Icons.settings.png")
            };
            Children.Add(settingsPage);
            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this,
                    Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSmoothScrollEnabled(this, false);
            }

            CurrentPage = _homePage;
        }

    }
}
