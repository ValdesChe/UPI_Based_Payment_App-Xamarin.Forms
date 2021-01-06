using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UPIBasedPaymentApp.Models
{
    public class TransactionItemGroup: ObservableCollection<Transaction>
    {
        public string Name { get; private set; }

        public TransactionItemGroup(string name): base()
        {
            Name = name;
        }

        public TransactionItemGroup(string name, 
            IEnumerable<Transaction> source) : base(source)
        {
            Name = name;
        }
    }
}
