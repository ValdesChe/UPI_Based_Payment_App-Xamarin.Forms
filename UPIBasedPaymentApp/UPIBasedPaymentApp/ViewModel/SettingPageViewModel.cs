using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UPIBasedPaymentApp.Enum;
using UPIBasedPaymentApp.Utilities;
using UPIBasedPaymentApp.ViewModel.Base;
using UPIBasedPaymentApp.Views.Settings;

namespace UPIBasedPaymentApp.ViewModel
{
    public class SettingPageViewModel : BaseViewModel
    {
        #region Props
        private ObservableCollection<SettingsPageListItem> _GroupedItems;
        private SettingsPageListItem _SelectedSettingsPageItem;
        #endregion

        public SettingPageViewModel(INavigationService navigationService):base(navigationService)
        {
            BuildMenuItems();
        }


        #region Methods
        public void BuildMenuItems()
        {
            var groupedItems = new List<SettingsPageListItem>();
            groupedItems.Add(new SettingsPageListItem()
            {
                Name = "My profile",
                Icon = FaIcons.Account,
                Type = SettingsType.PROFILE_EDIT
            });

            groupedItems.Add(new SettingsPageListItem()
            {
                Name = "Changes password",
                Icon = FaIcons.LockAlert,
                Type = SettingsType.PASSWORD_EDIT
            });

            groupedItems.Add(new SettingsPageListItem()
            {
                Name = "Changes language",
                Icon = FaIcons.GoogleTranslate,
                Type = SettingsType.LANGUAGE_EDIT
            });

            groupedItems.Add(new SettingsPageListItem()
            {
                Name = "Terms and conditions",
                Icon = FaIcons.ShieldHalfFull,
                Type = SettingsType.TERMS_COND_EDIT
            });

            GroupedItems = new ObservableCollection<SettingsPageListItem>(groupedItems);
        }

        #endregion




        #region Navigation


        private async void NavigateToMenuItemPage(SettingsType? type)
        {
            switch (type)
            {
                case SettingsType.PROFILE_EDIT:
                    await NavigateToProfileSettingsPage();
                    break;
                default:
                    await NavigateToProfileSettingsPage();
                    break;
            }
        }

        #endregion


        #region Commands
        public DelegateCommand BackToCommand
        {
            get; private set;
        }

        #endregion


        #region Fields

        public ObservableCollection<SettingsPageListItem> GroupedItems { get => _GroupedItems; set => SetProperty(ref _GroupedItems, value); }
        
        public SettingsPageListItem SelectedSettingsPageItem {
            get => _SelectedSettingsPageItem;
            set {
                SetProperty(ref _SelectedSettingsPageItem, value);
                if (value == null)
                    return;
                NavigateToMenuItemPage(value.Type);
            }
        }

        #endregion
    }
}
