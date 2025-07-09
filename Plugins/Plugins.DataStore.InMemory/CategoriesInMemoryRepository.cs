using CoreBusiness;
using UseCases.DataStorePluginInterface;
namespace Plugins.DataStore.InMemory
{
    public class CategoriesInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>{
            new Category { Id = 1 , Name = "Beverage" , Description = "Beverage" },
            new Category { Id = 2, Name = "Bakery", Description = "Bakery" },
            new Category { Id = 3, Name = "Meat", Description = "Meat" }};
        public void AddCategory(Category category)
        {
            var maxId = 0;
            if (_categories.Count != 0)
            {
                maxId = _categories.Max(x => x.Id);
            }

            category.Id = maxId + 1;
            _categories.Add(category);
        }



        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (category != null)
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

        public void UpdateCategory(int categoryId, Category category)
        {
            if (category.Id != categoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Id = categoryId;
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
        public void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
