using System.ComponentModel.DataAnnotations;

namespace Supermarket_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name="Category")]
        public int? CategoryId { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public double? Price { get; set; }
        [Required]
        public int? Quantity { get; set; }

        public Category? Category { get; set; }
    }
}
