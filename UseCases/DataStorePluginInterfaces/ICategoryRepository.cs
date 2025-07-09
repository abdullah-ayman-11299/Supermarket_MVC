using CoreBusiness;

namespace UseCases.DataStorePluginInterface
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        IEnumerable<Category> GetCategories();
        Category? GetCategoryById(int categoryId);
        void UpdateCategory(int categoryId, Category category);
    }
}