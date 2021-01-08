using Prism;
using Prism.Navigation;
using System;

namespace UPIBasedPaymentApp.ViewModel.Base
{
    public class TabbedPageBaseViewModel : BaseViewModel, IActiveAware
    {
        public bool _IsActive;
        public event EventHandler IsActiveChanged;

        public TabbedPageBaseViewModel(INavigationService navigationService): base(navigationService)
        {
        }

        #region Props

        public bool IsActive { 
            get => _IsActive; 
            set => SetProperty(ref _IsActive, value, RaisePropertyChanged); 
        }

        #endregion

        #region Event
        private void RaisePropertyChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty); ;
        }
        #endregion
    }
}
