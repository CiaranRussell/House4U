using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectTime.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [DisplayName("Department Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Rate/Hr")]
        public decimal Rate { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
