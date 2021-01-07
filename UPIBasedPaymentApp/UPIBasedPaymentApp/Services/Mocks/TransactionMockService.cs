
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPIBasedPaymentApp.Models;
using UPIBasedPaymentApp.Services.Abstractions;

namespace UPIBasedPaymentApp.Services.Mocks
{
    public class TransactionMockService : ITransactionService
    {

        private static List<Transaction> transactions = new List<Transaction>() {
            new Transaction()
            {
                Name = "Yogoni Joshi Transfert via Paypal",
                Amount = -100.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.DEBIT,
                Date = DateTime.Now
            },
            new Transaction()
            {
                Name = "Aurion : Legacy of the Kori-Adan payment via Kingui Cash - Kiroo Game",
                Amount = 125.75,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.CREDIT,
                Date = DateTime.Now
            },
            new Transaction()
            {
                Name = "Payment Salaire Nabulos Engineering - Mois Janvier 2021",
                Amount = 3072.50,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.CREDIT,
                Date = new DateTime(2021, 1, 1, 14, 23, 20)
            },
            new Transaction()
            {
                Name = "Airbnb Payments UK/Payments",
                Amount = -25.02,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.DEBIT,
                Date = new DateTime(2021, 1, 3, 20, 19, 20)
            },
            new Transaction()
            {
                Name = "Latif Transfert via Paypal",
                Amount = 1000.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.CREDIT,
                Date = new DateTime(2021, 1, 3, 18, 51, 20)
            },
            new Transaction()
            {
                Name = "Payment Assurance habitation Credit Mutuel",
                Amount = 15.5,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.CREDIT,
                Date = new DateTime(2020, 2, 17, 12, 23, 20)
            },
            new Transaction()
            {
                Name = "Payment Timbre Communal/ Credit Mutuel",
                Amount = -50.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.DEBIT,
                Date = new DateTime(2020, 2, 17, 12, 23, 20)
            },
            new Transaction()
            {
                Name = "Payment Taxe AMBACAM",
                Amount = -15.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.DEBIT,
                Date = new DateTime(2020, 4, 19, 14, 23, 20)
            },
            new Transaction()
            {
                Name = "Payment Salaire BOOMIT - Mois Avril 2020",
                Amount = 2735.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.CREDIT,
                Date = new DateTime(2020, 4, 19, 14, 23, 20)
            },
            new Transaction()
            {
                Name = "Paiement facture Hyper-marché SANTA LUCIA Yaounde",
                Amount = -48.0,
                Currency = Enum.CurrencyType.GBP,
                Type = Enum.TransactionType.DEBIT,
                Date = new DateTime(2020, 4, 12, 12, 03, 11)
            }

        };

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            await Task.Delay(2);

            return transactions;
        }

        public async Task<IEnumerable<TransactionItemGroup>> GetTransactionsGroupByDate()
        {
            await Task.Delay(2);
            return transactions.OrderByDescending(transaction => transaction.Date)
                .GroupBy(transaction => transaction.DateString,
                (key, g) => new TransactionItemGroup (key, g)
                ).ToList();
        }
    }
}
