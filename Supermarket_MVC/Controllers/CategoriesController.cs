//using CoreBusiness;
using Supermarket_MVC.Models;
using Microsoft.AspNetCore.Mvc;
//using UseCases.CategoriesUseCases.Interfaces;


namespace Supermarket_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly IViewCategoriesUseCase viewCategoriesUseCase;

        //public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase)
        //{
        //    this.viewCategoriesUseCase = viewCategoriesUseCase;
        //}
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)
        {
            ViewBag.Action = "Edit";
            var category = CategoriesRepository.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category catToEdit)
        {
            ViewBag.Action = "Edit";

            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(catToEdit.Id, catToEdit);
                return RedirectToAction(nameof(Index));
            }

            return View(catToEdit);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category catToAdd)
        {
            ViewBag.Action = "Add";

            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(catToAdd);
                return RedirectToAction(nameof(Index));
            }
            return View(catToAdd);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategoryById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
