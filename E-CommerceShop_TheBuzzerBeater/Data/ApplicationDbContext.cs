using E_CommerceShop_TheBuzzerBeater.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceShop_TheBuzzerBeater.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
