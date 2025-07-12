using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.TransactionsUseCases.Interfaces;

namespace UseCases.TransactionsUseCases
{
    public class ViewTransactionsByDayAndCashier : IViewTransactionsByDayAndCashier
    {
        private readonly ITransactionRepository transactionRepository;

        public ViewTransactionsByDayAndCashier(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName, DateTime date)
        {
            return transactionRepository.GetByDayAndCashier(cashierName, date);
        }
    }
}
