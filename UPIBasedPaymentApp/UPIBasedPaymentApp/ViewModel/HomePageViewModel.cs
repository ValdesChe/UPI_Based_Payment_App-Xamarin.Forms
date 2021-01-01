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
            BankAccountCommand = new DelegateCommand(BankAccountCommandExecute);
        }

        private void BankAccountCommandExecute()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            GoToBankAccountPage();
            IsBusy = false;        
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


        private async void GoToBankAccountPage()
        {
            await NavigateToBankAccountPage();
        }

        public DelegateCommand GenerateQrCodeCommand
        {
            get; private set;
        }

        public DelegateCommand BankAccountCommand
        {
            get; private set;
        }
    }
}
