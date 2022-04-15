using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace House4U.Data
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Lease { Managed, Delegated }
    public class HouseEntries
    {
        [Required(ErrorMessage = "Property ID is required")]
        public string ID { get; set; }

        [MinLength(1)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Number of Bedrooms required")]
        public int NumBedrooms { get; set; }

        public Lease Lease { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime leaseExpiry { get; set; }
    }
}
