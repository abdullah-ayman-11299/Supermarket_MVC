using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class AddTransaction : IAddTransaction
    {
        private readonly ITransactionRepository transactionRepository;

        public AddTransaction(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public void Execute(Transaction transaction)
        {
            transactionRepository.Add(transaction);
        }
    }
}
