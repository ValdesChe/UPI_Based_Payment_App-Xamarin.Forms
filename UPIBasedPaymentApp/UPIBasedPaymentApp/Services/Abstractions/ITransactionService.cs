using System.Collections.Generic;
using System.Threading.Tasks;
using UPIBasedPaymentApp.Models;

namespace UPIBasedPaymentApp.Services.Abstractions
{
    public interface ITransactionService
    {
        /// <summary>
        /// Fetch the transactions
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Transaction>> GetTransactions();
    }
}
