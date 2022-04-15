using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBookV3.Data
{
    public class PhoneBookV3Context : DbContext
    {
        public PhoneBookV3Context (DbContextOptions<PhoneBookV3Context> options)
            : base(options)
        {
        }

        public DbSet<PhoneBook.Models.PhoneBookEntry> PhoneBookEntry { get; set; }
    }
}
