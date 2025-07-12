namespace Supermarket_MVC.ViewModels
{
    public class ProductCategoriesViewModel
    {
        public IEnumerable<CoreBusiness.Category> categories { get; set; } = Enumerable.Empty<CoreBusiness.Category>();
        public CoreBusiness.Product Product { get; set; } = new CoreBusiness.Product();
    }
}
