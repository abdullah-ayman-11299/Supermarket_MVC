using CoreBusiness;

namespace UseCases.CategoriesUseCases.Interfaces
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryId);
    }
}