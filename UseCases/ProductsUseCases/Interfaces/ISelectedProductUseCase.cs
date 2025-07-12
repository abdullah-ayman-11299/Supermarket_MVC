using CoreBusiness;

namespace UseCases.ProductsUseCases
{
    public interface ISelectedProductUseCase
    {
        Product? Execute(int productId, bool loadCategory = false);
    }
}