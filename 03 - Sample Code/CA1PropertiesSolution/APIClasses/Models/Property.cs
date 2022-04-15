using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace House4U.Models
{
    public class Property
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(1,int.MaxValue)]
        public int BedroomCount { get; set; }

        [Required]
        public bool FullyDelegated { get; set; }

        [Required]
        public DateTime LeaseExpiry { get; set; }

        [Required] //foreign key provides relationship to Clients
        public int ClientID { get; set; }
    }
}