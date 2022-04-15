using System;
using System.ComponentModel.DataAnnotations;

namespace StockOrder.Models
{
    // an order for stock, with data annotations
    public class Order
    {
        [Required(ErrorMessage = "Item Code must not be blank!")]                                              // this property is required
        [StringLength(10)]
        public String ItemCode { get; set; }

        [Required(ErrorMessage = "Qty must not be blank!")]                                                    // this property is required
        [Range(1, 100, ErrorMessage = "Qty must be in range 1..100!")]
        public int Qty { get; set; }

        // also can use RegularExpressions
    }
}