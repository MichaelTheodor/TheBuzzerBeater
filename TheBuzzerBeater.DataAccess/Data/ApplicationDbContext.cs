using TheBuzzerBeater.Models;
using Microsoft.EntityFrameworkCore;


namespace TheBuzzerBeater.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Air Pumps", DisplayOrder = 1},
                new Category { CategoryId = 2, Name = "Arm Sleeves", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Balls", DisplayOrder = 3 },
                new Category { CategoryId = 4, Name = "Basket", DisplayOrder = 4 },
                new Category { CategoryId = 5, Name = "Basketball Nets", DisplayOrder = 5 },
                new Category { CategoryId = 6, Name = "Beanies", DisplayOrder = 6 },
                new Category { CategoryId = 7, Name = "Hats", DisplayOrder = 7 },
                new Category { CategoryId = 8, Name = "Headbands - Wristbands", DisplayOrder = 8 },
                new Category { CategoryId = 9, Name = "Hoodies", DisplayOrder = 9 },
                new Category { CategoryId = 10,Name = "Mugs & Cups", DisplayOrder = 10 },
                new Category { CategoryId = 11, Name = "ΝΒΑ Jerseys", DisplayOrder = 11 },
                new Category { CategoryId = 12,Name = "Shoes", DisplayOrder = 12},
                new Category { CategoryId = 13,Name = "Socks", DisplayOrder = 13 },
                new Category { CategoryId = 14,Name = "Stickers", DisplayOrder = 14 }
                );
        }
    }
}
