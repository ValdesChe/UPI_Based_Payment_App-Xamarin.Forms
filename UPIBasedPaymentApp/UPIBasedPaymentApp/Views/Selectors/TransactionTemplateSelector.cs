using System;
using System.Collections.Generic;
using System.Text;
using UPIBasedPaymentApp.Models;
using Xamarin.Forms;

namespace UPIBasedPaymentApp.Views.Selectors
{
    public class TransactionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CreditTemplate { get; set; }
        public DataTemplate DebitTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Transaction transactionItem)
            {
                return transactionItem.Type == Enum.TransactionType.CREDIT ? CreditTemplate : DebitTemplate;
            }
            return null;
        }
    }
}
