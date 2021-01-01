using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using UPIBasedPaymentApp.Views;
using UPIBasedPaymentApp.Views.Page;
using UPIBasedPaymentApp.Views.Settings;
using Xamarin.Forms;

namespace UPIBasedPaymentApp.ViewModel.Base
{
    public class BaseViewModel : BindableBase
    {
        private bool _IsBusy;
        private string _title;
        protected readonly INavigationService _NavigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _NavigationService = navigationService;
        }


        #region Props
        public bool IsBusy{
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }


        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion

        #region Navigate

        /***
         *  Navigate to homepage
         **/
        public async Task NavigateToMainPage()
        {
            NavigationParameters np = new NavigationParameters();
            await _NavigationService.NavigateAsync($"/{nameof(TabbedMainPage)}?{KnownNavigationParameters.SelectedTab}={nameof(HomePage)}", np);
        }

        /***
         *  Navigate to homepage
         **/
        public async Task NavigateBackToHomePage()
        {
            NavigationParameters np = new NavigationParameters();
            await _NavigationService.NavigateAsync($"/{nameof(TabbedMainPage)}?{KnownNavigationParameters.SelectedTab}={nameof(HomePage)}", np);
        }


        /***
         *  Navigate to generate Qr code page
         **/
        public async Task NavigateToGenerateQrCodePage()
        {
            NavigationParameters np = new NavigationParameters();
            await _NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(TabbedMainPage)}/{nameof(GenerateCodePage)}", np) ;
        }

        /***
         *  Navigate to Profile Settings Page
         **/
        public async Task NavigateToProfileSettingsPage()
        {
            await _NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(TabbedMainPage)}?{KnownNavigationParameters.SelectedTab}={nameof(HomePage)}/{nameof(ProfileSettingsPage)}") ;
        }

        #endregion
    }
}
