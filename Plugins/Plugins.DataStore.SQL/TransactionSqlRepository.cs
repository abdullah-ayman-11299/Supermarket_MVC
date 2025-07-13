using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionSqlRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionSqlRepository(MarketContext db)
        {
            this.db = db;
        }
        public void Add(Transaction transaction)
        {
            db.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(t => t.TimeStamp.Date == date.Date);
            }

            return db.Transactions.Where(t =>
                t.TimeStamp.Date == date.Date &&
                EF.Functions.Like(t.CashierName, $"%{cashierName}"));
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return db.Transactions.Where(t =>
                    t.TimeStamp.Date >= startDate.Date &&
                    t.TimeStamp.Date <= endDate.Date);
            }

            return db.Transactions.Where(t =>
                t.TimeStamp.Date >= startDate.Date &&
                t.TimeStamp.Date <= endDate.Date &&
                EF.Functions.Like(t.CashierName, $"%{cashierName}"));
        }
    }
}
