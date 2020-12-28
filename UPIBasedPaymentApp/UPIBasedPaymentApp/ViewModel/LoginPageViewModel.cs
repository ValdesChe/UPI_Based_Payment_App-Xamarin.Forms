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
            LoginCommand = new DelegateCommand(LoginCommandExecute);
        }


        private void LoginCommandExecute()
        {
            IsBusy = true;
            GoToHomePage();
            IsBusy = false;
        }

        private async void GoToHomePage()
        {
            await NavigateToMainPage();
        }


        #region CanExecute Methods
        bool CanLogin()
        {
            return !IsBusy;
        }
        #endregion

        #region Commands
        public DelegateCommand LoginCommand { get; private set; }
        #endregion
    }
}
