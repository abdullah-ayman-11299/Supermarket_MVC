using Supermarket_MVC.Models;

namespace Supermarket_MVC.Models
{
    public static class TransactionRepository
    {
        private static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
            {
                return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) &&  x.TimeStamp.Date == date.Date);
            }
        }

        public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => (x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date));
            else
                return transactions.Where(x => x.CashierName.ToLower().Contains(cashierName.ToLower()) && (x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date));

        }
        public static void Add(Transaction transaction)
        {
            var maxId = 0;
            if (transactions.Count != 0)
            {
                maxId = transactions.Max(x => x.Id);
            }
            transaction.Id = maxId + 1;
            transactions?.Add(transaction);
        }

    }
}
