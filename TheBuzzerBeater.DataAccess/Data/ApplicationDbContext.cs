using TheBuzzerBeater.Models;


using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;




namespace TheBuzzerBeater.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Product>().HasData(
                new Product {
                    ProductId = 1,
                    Name = "Nba Boston Celtics Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back - me - up - koupa - keramapli - nba - boston - celtics.jpg "
                },
                new Product {
                    ProductId = 2,
                    Name = "Nba Milwaukee Bucks Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back -me-up-koupa-keramapli-nba-bucks"
                },
                new Product {
                    ProductId = 3,
                    Name = "Nba Chicago Bulls Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back -me-up-koupa-keramapli-nba-bulls"
                },
                new Product {
                    ProductId = 4,
                    Name = "Nba Los Angeles Lakers Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back -me-up-koupa-keramapli-nba-la-lakers (1)"
                },
                new Product {
                    ProductId = 5,
                    Name = "Nba Los Angeles Lakers Cup 2",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back -me-up-koupa-keramapli-nba-la-lakers"
                },
                new Product {
                    ProductId = 6,
                    Name = "Nba Logo Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 5,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back -me-up-koupa-keramapli-nba-logo"
                }
                );
        }
    }
}


