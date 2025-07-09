using Supermarket_MVC.Models;
using Supermarket_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket_MVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts(true);
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var productViewModel = new ProductCategoriesViewModel
            {
                Product = ProductRepository.GetProductById(id)??new Product(),
                categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductCategoriesViewModel productViewModel)
        {
            ViewBag.Action = "Edit";

            if (ModelState.IsValid)
            {
                ProductRepository.UpdateProduct(productViewModel.Product.Id, productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ProductCategoriesViewModel productViewModel = new ProductCategoriesViewModel
            {
                categories = CategoriesRepository.GetCategories()
            };

            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductCategoriesViewModel productViewModel)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }
        public IActionResult Delete(int id)
        {
            ProductRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ProductCategoryPartial(int categoryId)
        {
            var products = ProductRepository.GetProductByCategoryId(categoryId);
            return PartialView("_Products",products);
        }
    }
}
