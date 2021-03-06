﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UPIBasedPaymentApp.Models;
using UPIBasedPaymentApp.Services.Abstractions;
using UPIBasedPaymentApp.ViewModel.Base;

namespace UPIBasedPaymentApp.ViewModel
{
    public class BankAccountPageViewModel : BaseViewModel
    {
        protected readonly ITransactionService _TransactionService;
        public ObservableCollection<TransactionItemGroup> _Transactions;


        #region Constructor

        public BankAccountPageViewModel(INavigationService navigationService,
            ITransactionService transactionService): base(navigationService)
        {
            _TransactionService = transactionService;
            FetchTransactions();
        }

        #endregion


        #region Builder
        
        public async void FetchTransactions()
        {
            var transactions = await _TransactionService.GetTransactionsGroupByDate();
            Transactions = new ObservableCollection<TransactionItemGroup>(transactions);
        }

        #endregion

        #region Props

        public ObservableCollection<TransactionItemGroup> Transactions
        {
            get => _Transactions;
            set => SetProperty(ref _Transactions, value);
        }

        #endregion

    }
}
