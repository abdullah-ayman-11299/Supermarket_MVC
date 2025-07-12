using CoreBusiness;

namespace UseCases.ProductsUseCases
{
    public interface IViewProductsByCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}