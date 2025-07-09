using Supermarket_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket_MVC.ViewComponents
{
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionRepository.GetByDayAndCashier(userName,DateTime.Now);
            return View(transactions);
        }
    }
}
