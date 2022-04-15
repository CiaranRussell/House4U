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

        public override string ToString()
        {
            return string.Format("Number: {0} | Name: {1} | Address: {2}", PhoneNumber, Name, Address);
        }

        public string ToJSON()
        {
            return string.Format("\"phoneNumber\": \"{0}\", \"name\": \"{1}\", \"address\": \"{2}\"", PhoneNumber, Name, Address);
        }

    }
}
