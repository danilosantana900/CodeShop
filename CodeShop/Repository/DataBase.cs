using Microsoft.EntityFrameworkCore;

namespace CodeShop.Repository.DataModel
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ModelCreate();
            modelBuilder.SeedData();
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
