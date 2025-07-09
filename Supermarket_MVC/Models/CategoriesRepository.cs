using Supermarket_MVC.Models;

namespace Supermarket_MVC.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>{ 
            new Category { Id = 1 , Name = "Beverage" , Description = "Beverage" }, 
            new Category { Id = 2, Name = "Bakery", Description = "Bakery" }, 
            new Category { Id = 3, Name = "Meat", Description = "Meat" }};

        public static void AddCategory(Category category)
        {
            var maxId = 0;
            if (_categories.Count != 0)
            {
                maxId = _categories.Max(x => x.Id);
            }
            
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int? id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);
            if(category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;
        }

        public static void UpdateCategory(int id, Category _category)
        {

            if (_category.Id != id) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Id = id;
                categoryToUpdate.Name = _category.Name;
                categoryToUpdate.Description = _category.Description;
            }
        }

        public static void DeleteCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);
            if( category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
