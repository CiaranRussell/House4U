using Microsoft.EntityFrameworkCore;


namespace EFCoreDemo
{
    public class PhoneBookContext : DbContext
    {

        public DbSet<PhoneBook> PhoneBooks {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=UPE002616;Database=EnityFramework;Trusted_Connection=True;MultipleActiveResultSets=true");
        }



    }
}