using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUseCases.Interfaces
{
    public interface IAddCategoryUseCase
    {
        public void Execute(Category category);
    }
}
