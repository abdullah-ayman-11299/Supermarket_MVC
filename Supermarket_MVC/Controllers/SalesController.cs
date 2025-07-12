//using CoreBusiness;
using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases.Interfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;

namespace Supermarket_MVC.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly ISelectedProductUseCase selectedProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IAddTransaction addTransaction;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,ISelectedProductUseCase selectedProductUseCase,IEditProductUseCase editProductUseCase,IAddTransaction addTransaction)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.selectedProductUseCase = selectedProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.addTransaction = addTransaction;
        }
        public IActionResult Index(int? selectedCategoryId)
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute(),
                SelectedCategoryId = selectedCategoryId??0,
            };
            return View(salesViewModel);
        }
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                var pro = selectedProductUseCase.Execute(salesViewModel.SelectedProductId);
                if (pro != null)
                {
                    var trans = new CoreBusiness.Transaction
                    {
                        CashierName = "Cashier1",
                        TimeStamp = DateTime.Now,
                        ProductId = salesViewModel.SelectedProductId,
                        ProductName = pro.Name,
                        Price = pro.Price ?? 0,
                        BeforeQty = pro.Quantity ?? 0,
                        SoldQty = salesViewModel.QuantityToSell ?? 0
                    };
                    addTransaction.Execute(trans);


                    pro.Quantity -= salesViewModel.QuantityToSell;
                    editProductUseCase.Execute(salesViewModel.SelectedProductId, pro);
                }
            }
            var product = selectedProductUseCase.Execute(salesViewModel.SelectedProductId);

            salesViewModel.SelectedCategoryId = (product?.CategoryId == null)?0:product.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();
            return RedirectToAction(nameof(Index), new { selectedCategoryId = salesViewModel.SelectedCategoryId});
        }
        public IActionResult SellProductPartial(int id)
        {
            var product = selectedProductUseCase.Execute(id);
            return PartialView("_SellProduct", product);
        }
    }
}
