using Bulky.ModelsData;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccessData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Action", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    Id = 1,
                    Title = "Title1",
                    Description =  "Description 1",
                    ISBN = "ISBN 1",
                    Author = "Author 1",
                    ListPrice = 101.0,
                    Price =100.0,
                    Price50 = 91.0,
                    Price100 = 90.0
                },
                new Product
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description 2",
                    ISBN = "ISBN 2",
                    Author = "Author 2",
                    ListPrice = 101.0,
                    Price = 100.0,
                    Price50 = 91.0,
                    Price100 = 90.0
                },
                new Product
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description 3",
                    ISBN = "ISBN 3",
                    Author = "Author 3",
                    ListPrice = 101.0,
                    Price = 100.0,
                    Price50 = 91.0,
                    Price100 = 90.0
                }
            );
        }
    }
}
