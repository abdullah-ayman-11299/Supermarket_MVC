using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCases.Interfaces;

namespace Supermarket_MVC.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionsSearch transactionsSearch;

        public TransactionsController(ITransactionsSearch transactionsSearch)
        {
            this.transactionsSearch = transactionsSearch;
        }
        public IActionResult Index(TransactionViewModel tranViewModel)
        {
            return View(tranViewModel);
        }
        public IActionResult Search(TransactionViewModel tranViewModel)
        {
            tranViewModel.Transactions = transactionsSearch.Execute(tranViewModel.CashierName??string.Empty, tranViewModel.StartDate,tranViewModel.EndDate); 
            return View(nameof(Index) , tranViewModel);
        }
    }
}
