using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket_MVC.ViewModels;
using UseCases.CategoriesUseCases.Interfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;

namespace Supermarket_MVC.Controllers
{
    [Authorize(Policy = "Cashiers")]
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly ISelectedProductUseCase selectedProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IAddTransaction addTransaction;
        private readonly IViewProductsByCategoryUseCase viewProductsByCategoryUseCase;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase, ISelectedProductUseCase selectedProductUseCase, IEditProductUseCase editProductUseCase, IAddTransaction addTransaction, IViewProductsByCategoryUseCase viewProductsByCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.selectedProductUseCase = selectedProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.addTransaction = addTransaction;
            this.viewProductsByCategoryUseCase = viewProductsByCategoryUseCase;

        }
        public IActionResult Index(int? selectedCategoryId)
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute(),
                SelectedCategoryId = selectedCategoryId ?? 0,
            };
            return View(salesViewModel);
        }
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            var pro = selectedProductUseCase.Execute(salesViewModel.SelectedProductId);
            if (ModelState.IsValid)
            {
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
                    addTransaction.Execute(trans);

                    pro.Quantity -= salesViewModel.QuantityToSell;

                    editProductUseCase.Execute(salesViewModel.SelectedProductId, pro);

                    salesViewModel.SelectedCategoryId = (pro?.CategoryId == null) ? 0 : pro.CategoryId.Value;
                    salesViewModel.Categories = viewCategoriesUseCase.Execute();
                    return RedirectToAction(nameof(Index), new { selectedCategoryId = salesViewModel.SelectedCategoryId });

                }
            }

            salesViewModel.SelectedCategoryId = (pro?.CategoryId == null) ? 0 : pro.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(nameof(Index), salesViewModel);
        }
        public IActionResult SellProductPartial(int id)
        {
            var product = selectedProductUseCase.Execute(id);
            return PartialView("_SellProduct", product);
        }
        public IActionResult ProductCategoryPartial(int categoryId)
        {
            var products = viewProductsByCategoryUseCase.Execute(categoryId);
            return PartialView("_Products", products);
        }
    }
}
