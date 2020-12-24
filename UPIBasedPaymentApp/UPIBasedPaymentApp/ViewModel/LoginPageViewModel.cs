using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(INavigationService navigationService): base(navigationService)
        {
            LoginActionCommand = new DelegateCommand(LoginActionCommandExecute, () => !IsBusy);
        }


        private void LoginActionCommandExecute()
        {
            IsBusy = true;
            GoToHomePage();
            IsBusy = false;
        }

        private async void GoToHomePage()
        {
            await NavigateToHomePage();
        }

        #region Commands
        public DelegateCommand LoginActionCommand { get; set; }
        #endregion
    }
}
