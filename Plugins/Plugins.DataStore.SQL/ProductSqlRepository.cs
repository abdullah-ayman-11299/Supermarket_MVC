using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductSqlRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductSqlRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);
            if (productToDelete == null) return;


            db.Products.Remove(productToDelete);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return db.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product? GetProductById(int productId, bool loadCategory = false)
        {
            if (loadCategory)
            {
                return db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
            }
            return db.Products.FirstOrDefault(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(bool loadCategory = false)
        {
            if (loadCategory)
            {
                return db.Products.Include(p => p.Category).OrderBy(p => p.CategoryId).ToList();
            }
            return db.Products.OrderBy(p => p.CategoryId).ToList();
        }

        public void UpdateProduct(int productId, Product product)
        {
            if(product.Id != productId) return;

            var productToUpdate = GetProductById(productId);

            if (productToUpdate == null) return;

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Quantity = product.Quantity;

            db.SaveChanges();
        }
    }
}
