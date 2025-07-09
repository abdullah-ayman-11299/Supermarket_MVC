//using CoreBusiness;
using Supermarket_MVC.Models;
using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket_MVC.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index(int? selectedCategoryId)
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories(),
                SelectedCategoryId = selectedCategoryId??0,
            };
            return View(salesViewModel);
        }
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                var pro = ProductRepository.GetProductById(salesViewModel.SelectedProductId);
                if (pro != null)
                {
                    var trans = new Transaction
                    {
                        CashierName = "Cashier1",
                        TimeStamp = DateTime.Now,
                        ProductId = salesViewModel.SelectedProductId,
                        ProductName = pro.Name,
                        Price = pro.Price ?? 0,
                        BeforeQty = pro.Quantity ?? 0,
                        SoldQty = salesViewModel.QuantityToSell ?? 0
                    };
                    TransactionRepository.Add(trans);


                    pro.Quantity -= salesViewModel.QuantityToSell;
                    ProductRepository.UpdateProduct(salesViewModel.SelectedProductId, pro);
                }
            }
            var product = ProductRepository.GetProductById(salesViewModel.SelectedProductId);

            salesViewModel.SelectedCategoryId = (product?.CategoryId == null)?0:product.CategoryId.Value;
            salesViewModel.Categories = CategoriesRepository.GetCategories();
            return RedirectToAction(nameof(Index), new { selectedCategoryId = salesViewModel.SelectedCategoryId});
        }
        public IActionResult SellProductPartial(int id)
        {
            var product = ProductRepository.GetProductById(id);
            return PartialView("_SellProduct", product);
        }
    }
}
