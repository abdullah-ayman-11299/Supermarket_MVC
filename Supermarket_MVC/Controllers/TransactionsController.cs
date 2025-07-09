using Supermarket_MVC.Models;
using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket_MVC.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index(TransactionViewModel tranViewModel)
        {
            return View(tranViewModel);
        }
        public IActionResult Search(TransactionViewModel tranViewModel)
        {
            tranViewModel.Transactions = TransactionRepository.Search(tranViewModel.CashierName??string.Empty, tranViewModel.StartDate,tranViewModel.EndDate); 
            return View(nameof(Index) , tranViewModel);
        }
    }
}
