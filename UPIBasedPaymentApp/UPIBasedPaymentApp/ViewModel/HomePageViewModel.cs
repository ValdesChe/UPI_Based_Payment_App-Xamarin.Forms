using Prism.Commands;
using Prism.Navigation;
using System;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService):base(navigationService)
        {
            GenerateQrCodeCommand = new DelegateCommand(GenerateQrCodeCommandExecute);
        }

        private void GenerateQrCodeCommandExecute()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            GoToGenerateQrCodePage();
            IsBusy = false;        
        }

        private async void GoToGenerateQrCodePage()
        {
            await NavigateToGenerateQrCodePage();
        }

        public DelegateCommand GenerateQrCodeCommand
        {
            get; private set;
        }
    }
}
