using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace House4U.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    }
}