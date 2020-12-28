using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class TabbedMainPageViewModel : BaseViewModel
    {
        public TabbedMainPageViewModel(INavigationService navigationService):base(navigationService)
        {

        }
    }
}
