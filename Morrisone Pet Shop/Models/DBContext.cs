using Microsoft.EntityFrameworkCore;

namespace Morrisone_Pet_Shop.Areas
{
    public class DBContext:DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=MorrisonePetShop;integrated security=true;");
            base.OnConfiguring(optionsBuilder); 

        }
    }
}
