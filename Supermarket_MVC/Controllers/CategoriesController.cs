using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCases.Interfaces;


namespace Supermarket_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase viewSelectedCategoryUseCase;
        private readonly IAddCategoryUseCase addCategoryUseCase;
        private readonly IEditCategoryUseCase editCategoryUseCase;
        private readonly IDeleteCategoryUseCase deleteCategoryUseCase;

        public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase , IViewSelectedCategoryUseCase viewSelectedCategoryUseCase , IAddCategoryUseCase addCategoryUseCase , IEditCategoryUseCase editCategoryUseCase, IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            this.addCategoryUseCase = addCategoryUseCase;
            this.editCategoryUseCase = editCategoryUseCase;
            this.deleteCategoryUseCase = deleteCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories = viewCategoriesUseCase.Execute();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int id)
        {
            ViewBag.Action = "Edit";
            var category = viewSelectedCategoryUseCase.Execute(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(CoreBusiness.Category catToEdit)
        {
            ViewBag.Action = "Edit";

            if (ModelState.IsValid)
            {
                editCategoryUseCase.Execute(catToEdit.Id, catToEdit);
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
        public IActionResult Add(CoreBusiness.Category catToAdd)
        {
            ViewBag.Action = "Add";

            if (ModelState.IsValid)
            {
                addCategoryUseCase.Execute(catToAdd);
                return RedirectToAction(nameof(Index));
            }
            return View(catToAdd);
        }

        public IActionResult Delete(int id)
        {
            deleteCategoryUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
