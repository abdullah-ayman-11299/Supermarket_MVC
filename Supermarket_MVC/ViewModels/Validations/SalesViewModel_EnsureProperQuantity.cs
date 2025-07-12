
using System.ComponentModel.DataAnnotations;
using UseCases.ProductsUseCases;

namespace Supermarket_MVC.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var selectedProductUseCase = validationContext.GetService(typeof(ISelectedProductUseCase)) as ISelectedProductUseCase;

            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
            if (salesViewModel != null)
            {
                if(salesViewModel.QuantityToSell <= 0 )
                {
                    return new ValidationResult("The Quantity to sell has to be greater than zero.");
                }else
                {
                    var product = selectedProductUseCase!.Execute(salesViewModel.SelectedProductId);
                    if (product != null)
                    {
                        if(product.Quantity < salesViewModel.QuantityToSell)
                        {
                            return new ValidationResult($"The {product.Name} only has {product.Quantity} left. It is not enough");
                        }
                    }
                    else
                    {
                        return new ValidationResult($"The selected product doesn't exsist.");
                    }
                    
                }
            }
            return ValidationResult.Success;
        }
    }
}
