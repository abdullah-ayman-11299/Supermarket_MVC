using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        IEnumerable<Product> GetProducts(bool loadCategory = false);
        IEnumerable<Product> GetProductByCategoryId(int categoryId);
        Product? GetProductById(int productId, bool loadCategory = false);
        void UpdateProduct(int productId, Product product);
    }
}
