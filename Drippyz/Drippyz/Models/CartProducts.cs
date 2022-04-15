using System.ComponentModel.DataAnnotations;

namespace Drippyz.Models
{
    public class CartProducts : Products
    {
        [Required(ErrorMessage = "Quanity is required")]
        public int Quanity { get; set; }
    }
}
