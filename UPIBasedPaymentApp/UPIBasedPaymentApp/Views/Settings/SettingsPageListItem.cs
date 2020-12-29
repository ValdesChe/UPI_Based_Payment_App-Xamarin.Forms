using System;
using System.Collections.Generic;
using System.Text;
using UPIBasedPaymentApp.Enum;

namespace UPIBasedPaymentApp.Views.Settings
{
    public class SettingsPageListItem
    {
        private string _icon;
        private string _name;

        public SettingsType? Type { get; set; }

        public string Name
        {
            get => _name;
            set { _name = value; }
        }


        public string Icon
        {
            get => _icon;
            set { _icon = value; }
        }
    }
}
