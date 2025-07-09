using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUseCases.Interfaces
{
    public interface IEditCategoryUseCase
    {
        public void Execute(int categoryId, Category category);
    }
}
