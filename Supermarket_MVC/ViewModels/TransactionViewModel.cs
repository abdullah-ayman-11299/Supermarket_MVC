
using System.ComponentModel.DataAnnotations;

namespace Supermarket_MVC.ViewModels
{
    public class TransactionViewModel
    {
        [Display(Name = "Cashier Name")]
        public string? CashierName { get; set; } = string.Empty;
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public IEnumerable<CoreBusiness.Transaction> Transactions { get; set; }= new List<CoreBusiness.Transaction>();

    }
}
