using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using CoreBusiness;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions = new List<Transaction>();
        public void Add(Transaction transaction)
        {
            var maxId = 0;
            if (transactions.Count != 0)
            {
                maxId = transactions.Max(x => x.Id);
            }
            transaction.Id = maxId + 1;
            transactions?.Add(transaction);
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
            {
                return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && x.TimeStamp.Date == date.Date);
            }
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => (x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date));
            else
                return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && (x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date));
        }
    }
}
