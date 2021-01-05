using Prism.Mvvm;
using System;
using System.Globalization;
using UPIBasedPaymentApp.Enum;

namespace UPIBasedPaymentApp.Models
{
    public class Transaction
    {
        public string Name { get; set; }
        public TransactionType Type { get; set; }
        public CurrencyType Currency { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public string HourMinute { get => Date.ToString("hh:mm tt", CultureInfo.InvariantCulture); }
    }
}
