using Prism.Commands;
using Prism.Navigation;
using System;
using Unity;
using UPIBasedPaymentApp.Interfaces;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class GenerateCodePageViewModel : BaseViewModel
    {

        public GenerateCodePageViewModel(INavigationService navigationService) :base(navigationService)
        {
            Title = "Generate Qr Code";
        }

    }
}
