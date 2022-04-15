using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class PhoneBookEntry
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
