using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Drippyz.Models
{
    public class Products
    {   
        [Key]
        [RegularExpression(@"^[A-Z''-'\s]{3,3}[\d]{3,3}$",
         ErrorMessage = "Product code format is strictly 'AAA999'")]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        [DisplayName("Price (€)")]
        public double ProductPrice { get; set; }

        [DisplayName("Description")]
        [MaxLength(140, ErrorMessage = "Description must not contain more than 140 characters")]
        public string ProductDescription { get; set; }
    }
}
