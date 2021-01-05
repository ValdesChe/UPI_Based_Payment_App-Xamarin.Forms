using Prism.Mvvm;
using System;
using System.Globalization;
using UPIBasedPaymentApp.Enum;
using UPIBasedPaymentApp.Utilities;

namespace UPIBasedPaymentApp.Models
{
    public class Transaction
    {


        public string Name { get; set; }
        public TransactionType Type { get; set; }
        public CurrencyType Currency { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public String _Icon;
        public String Icon { 
            get {
                if (_Icon != null)
                {
                    return _Icon;
                }

                else if (Type == TransactionType.CREDIT)
                    _Icon = FaIcons.BankTransferIn;
                else
                    _Icon = FaIcons.BankTransferOut;

                return _Icon;
            }
        }
        public string HourMinute { get => Date.ToString("hh:mm tt", CultureInfo.InvariantCulture); }
    }
}
