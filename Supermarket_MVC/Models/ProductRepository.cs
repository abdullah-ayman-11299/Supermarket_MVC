
namespace Supermarket_MVC.Models
{
    public static class ProductRepository
    {
        private static List<Product> Products = new List<Product> {
           new Product{Id= 1, Name="Ice Tea",CategoryId = 1,Price= 1.99d,Quantity=95},
           new Product{Id= 2, Name="Canada Dry",CategoryId = 1,Price= 1.99d,Quantity=195},
           new Product{Id= 3, Name="Water",CategoryId = 1,Price= 1.00d,Quantity=30},
        };
        public static void AddProduct(Product product)
        {
            var maxId = 0;
            if (Products.Count != 0)
            {
                maxId = Products.Max(x => x.Id);
            }

            product.Id = maxId + 1;
            Products.Add(product);
        }
        public static List<Product> GetProducts(bool loadCategory = false)
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
                        if(x.CategoryId.HasValue)
                        {
                            x.Category = CategoriesRepository.GetCategoryById(x.CategoryId.Value);
                        }
                    });
                }
                return Products ?? new List<Product>();
            }
        }
        public static Product? GetProductById(int id , bool loadCategory = false)
        {
            var product = Products.FirstOrDefault(x => x.Id == id)!;
            if (loadCategory && product.CategoryId.HasValue)
            {
                product.Category = CategoriesRepository.GetCategoryById(product.CategoryId.Value);
            }
            return product;
        }

        public static void DeleteProduct(int id)
        {
            var productToDelete = GetProductById(id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
        }
        public static void UpdateProduct(int id, Product product)
        {
            if (product.Id != id) return;

            var productToUpdate = GetProductById(id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }

        public static List<Product> GetProductByCategoryId(int categoryId)
        {
            var products = Products.Where(x => x.CategoryId == categoryId).ToList();
            return products??new List<Product>();
        }
    }
}
