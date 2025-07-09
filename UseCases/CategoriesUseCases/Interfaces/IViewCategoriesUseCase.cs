using CoreBusiness;

namespace UseCases.CategoriesUseCases.Interfaces
{
    public interface IViewCategoriesUseCase 
    {
        IEnumerable<Category> Execute();
    }
}