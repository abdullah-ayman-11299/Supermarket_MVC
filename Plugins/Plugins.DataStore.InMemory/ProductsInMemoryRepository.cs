using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UseCases.DataStorePluginInterface;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductsInMemoryRepository : IProductRepository
    {
        private readonly ICategoryRepository categoryRepository;
        
        private List<Product> Products = new List<Product> {
           new Product{Id= 1, Name="Ice Tea",CategoryId = 1,Price= 1.99d,Quantity=95},
           new Product{Id= 2, Name="Canada Dry",CategoryId = 1,Price= 1.99d,Quantity=195},
           new Product{Id= 3, Name="Water",CategoryId = 1,Price= 1.00d,Quantity=30},
        };

        public ProductsInMemoryRepository(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void AddProduct(Product product)
        {
            var maxId = 0;
            if (Products.Count != 0)
            {
                maxId = Products.Max(x => x.Id);
            }

            product.Id = maxId + 1;
            Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            var products = Products.Where(x => x.CategoryId == categoryId).ToList();
            return products ?? new List<Product>();
        }

        public Product? GetProductById(int productId , bool loadCategory = false)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId)!;
            if (loadCategory && product.CategoryId.HasValue)
            {
                product.Category = categoryRepository.GetCategoryById(product.CategoryId.Value);
            }
            return product;
        }

        public IEnumerable<Product> GetProducts(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return Products;
            }
            else
            {
                if (Products != null && Products.Count > 0)
                {
                    Products.ForEach(x =>
                    {
                        if (x.CategoryId.HasValue)
                        {
                            x.Category = categoryRepository.GetCategoryById(x.CategoryId.Value);
                        }
                    });
                }
                return Products ?? new List<Product>();
            }
        }

        public void UpdateProduct(int productId, Product product)
        {
            if (product.Id != productId) return;

            var productToUpdate = GetProductById(productId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }
    }
}
