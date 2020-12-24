using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UPIBasedPaymentApp.ViewModel.Base
{
    public class BaseViewModel : BindableBase
    {
        private bool _IsBusy;
        private readonly INavigationService _NavigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _NavigationService = navigationService;
        }

        public bool IsBusy{
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }

        public async Task NavigateToHomePage()
        {
            NavigationParameters np = new NavigationParameters();
            await _NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
        }
    }
}
