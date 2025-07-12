using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.TransactionsUseCases.Interfaces
{
    public interface IViewTransactionsByDayAndCashier
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime date);
    }
}
