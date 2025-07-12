
using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UseCases.ProductsUseCases;
using UseCases.CategoriesUseCases.Interfaces;

namespace Supermarket_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IAddProductUseCase addProductUseCase;
        private readonly ISelectedProductUseCase selectedProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewProductsByCategoryUseCase viewProductsByCategoryUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;

        public ProductsController(IViewCategoriesUseCase viewCategoriesUseCase,IAddProductUseCase addProductUseCase , ISelectedProductUseCase selectedProductUseCase ,IEditProductUseCase editProductUseCase, IDeleteProductUseCase deleteProductUseCase , IViewProductsByCategoryUseCase viewProductsByCategoryUseCase , IViewProductsUseCase viewProductsUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.addProductUseCase = addProductUseCase;
            this.selectedProductUseCase = selectedProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewProductsByCategoryUseCase = viewProductsByCategoryUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
        }
        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(true);
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var productViewModel = new ProductCategoriesViewModel
            {
                Product = selectedProductUseCase.Execute(id)?? new CoreBusiness.Product(),
                categories = viewCategoriesUseCase.Execute()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategoriesViewModel productViewModel)
        {
            ViewBag.Action = "Edit";

            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productViewModel.Product.Id, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ProductCategoriesViewModel productViewModel = new ProductCategoriesViewModel
            {
                categories = viewCategoriesUseCase.Execute()
            };

            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductCategoriesViewModel productViewModel)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.categories = viewCategoriesUseCase.Execute();
            return View(productViewModel);
        }
        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductCategoryPartial(int categoryId)
        {
            var products = viewProductsByCategoryUseCase.Execute(categoryId);
            return PartialView("_Products",products);
        }
    }
}
