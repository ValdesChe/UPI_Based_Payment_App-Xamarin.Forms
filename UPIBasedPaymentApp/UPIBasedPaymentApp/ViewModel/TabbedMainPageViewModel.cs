using Prism.Navigation;
using Unity;
using Unity.Lifetime;
using UPIBasedPaymentApp.Enum;
using UPIBasedPaymentApp.Interfaces;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class TabbedMainPageViewModel : BaseViewModel, ITabbedMainPageSelectedTab
    {
        private readonly IUnityContainer _unityContainer;
        private int _selectedTab;

        public TabbedMainPageViewModel(INavigationService navigationService, IUnityContainer unityContainer) :base(navigationService)
        {
            _unityContainer = unityContainer;

            // Register this instance so we can access it anywhere in the code
            _unityContainer.RegisterInstance<ITabbedMainPageSelectedTab>(this, new ContainerControlledLifetimeManager());

        }

        public int SelectedTab {
            get { return _selectedTab; }
            set
            {
                SetProperty(ref _selectedTab, value);
                switch (value) {
                    case (int)TabType.HOME_PAGE:
                        Title = AppSettings.HomePage;
                    break;
                    case (int)TabType.NOTIFICATION_PAGE:
                        Title = AppSettings.NotificationPage;
                        break;

                    case (int)TabType.SETTINGS_PAGE:
                        Title = AppSettings.SettingsPage;
                        break;
                    default:
                        Title = "Default";
                        break;
                }
            }
        }

        public void SetSelectedTab(int tabIndex)
        {
            SelectedTab = tabIndex;
        }
    }
}
