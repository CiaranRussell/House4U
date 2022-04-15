using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    internal class Context : DbContext
    {
        public DbSet<PhoneBookEntry> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=UPE002616;Database=NewPhoneBook;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
