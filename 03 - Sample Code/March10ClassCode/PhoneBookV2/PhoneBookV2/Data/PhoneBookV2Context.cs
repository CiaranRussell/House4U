using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBookV2.Data
{
    public class PhoneBookV2Context : DbContext
    {
        public PhoneBookV2Context (DbContextOptions<PhoneBookV2Context> options)
            : base(options)
        {
        }

        public DbSet<PhoneBook.Models.PhoneBookEntry> PhoneBookEntry { get; set; }
    }
}
