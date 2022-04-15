using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EFCoreDemo
{
    public class PhoneBook
    {
        [Key]
        public int ID {get;set;}
        public int PhoneNumber {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Address {get; set;}


        public override string ToString()
        {
            return string.Format("Phone Number: {0} | Name: {1} | Address: {2}",PhoneNumber,Name,Address);
        }
    }
}