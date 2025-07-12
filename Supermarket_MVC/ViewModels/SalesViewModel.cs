//using CoreBusiness;

using Supermarket_MVC.ViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace Supermarket_MVC.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<CoreBusiness.Category> Categories { get; set; } = Enumerable.Empty<CoreBusiness.Category>();

        public int SelectedProductId { get; set; }
        [Display(Name ="Quantity")]
        [Range(1,int.MaxValue ,ErrorMessage ="The Quantity value is Invalid.")]
        [Required(ErrorMessage = "The Quantity value is required.")]
        [SalesViewModel_EnsureProperQuantity]
        public int? QuantityToSell { get; set; }
    }
}
