using Xamarin.Forms;

namespace UPIBasedPaymentApp.Views.Page
{
    public class BaseContentPage : ContentPage
    {
        public new void SendAppearing()
        {
            OnAppearing();
        }

        public new void SendDisappearing()
        {
            OnDisappearing();
        }
    }
}
