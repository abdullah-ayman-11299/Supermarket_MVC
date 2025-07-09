

using Supermarket_MVC.Models;

namespace Supermarket_MVC.ViewModels
{
    public class ProductCategoriesViewModel
    {
        public IEnumerable<Category> categories { get; set; } = Enumerable.Empty<Category>();
        public Product Product { get; set; } = new Product();
    }
}
