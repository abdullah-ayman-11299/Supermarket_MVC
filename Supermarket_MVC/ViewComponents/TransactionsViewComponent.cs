
using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCases.Interfaces;

namespace Supermarket_MVC.ViewComponents
{
    public class TransactionsViewComponent : ViewComponent
    {
        private readonly IViewTransactionsByDayAndCashier viewTransactionsByDayAndCashier;

        public TransactionsViewComponent(IViewTransactionsByDayAndCashier viewTransactionsByDayAndCashier)
        {
            this.viewTransactionsByDayAndCashier = viewTransactionsByDayAndCashier;
        }
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = viewTransactionsByDayAndCashier.Execute(userName,DateTime.Now);
            return View(transactions);
        }
    }
}
