using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterface;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SelectedProductUseCase : ISelectedProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SelectedProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product? Execute(int productId, bool loadCategory)
        {
           return productRepository.GetProductById(productId,loadCategory);
        }
    }
}
