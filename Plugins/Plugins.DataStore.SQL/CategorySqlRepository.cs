using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterface;

namespace Plugins.DataStore.SQL
{
    public class CategorySqlRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategorySqlRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();

        }

        public Category? GetCategoryById(int categoryId)
        {
            return db.Categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public void UpdateCategory(int categoryId, Category category)
        {
            if (category.Id != category.Id) return;

            var catToUpdate = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (catToUpdate == null) return;

            catToUpdate.Name = category.Name;
            catToUpdate.Description = category.Description;

            db.SaveChanges();
        }
    }
}
