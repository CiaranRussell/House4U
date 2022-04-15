using System.ComponentModel.DataAnnotations;

namespace PhoneBookAPI.Models
{
    public class PhoneBookEntry
    {
        [Key]
        public string PhoneNumber { get;set;}

        [Required]
        public string Name { get;set;}

        public string Address { get;set;}

    }
}
