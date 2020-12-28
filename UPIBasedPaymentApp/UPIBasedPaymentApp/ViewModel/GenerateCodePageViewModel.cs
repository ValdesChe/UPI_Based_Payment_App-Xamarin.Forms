using Prism.Commands;
using Prism.Navigation;
using System;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class GenerateCodePageViewModel : BaseViewModel
    {
        public GenerateCodePageViewModel(INavigationService navigationService):base(navigationService)
        {
            BackToCommand = new DelegateCommand(BackToCommandExecute);
        }

        private void BackToCommandExecute()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            GoBack();
            IsBusy = false;
        }

        private async void GoBack()
        {
            await NavigateBackToHomePage();
        }

        #region Commands
        public DelegateCommand BackToCommand
        {
            get; private set;
        }

        #endregion
    }
}
