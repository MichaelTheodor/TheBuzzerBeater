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
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Air Pumps", DisplayOrder = 1}, //ok
                new Category { CategoryId = 2, Name = "Arm Sleeves", DisplayOrder = 2 }, //check
                new Category { CategoryId = 3, Name = "Balls", DisplayOrder = 3 }, //check
                new Category { CategoryId = 4, Name = "Basket", DisplayOrder = 4 },
                new Category { CategoryId = 5, Name = "Basketball Nets", DisplayOrder = 5 },
                new Category { CategoryId = 6, Name = "Beanies", DisplayOrder = 6 },
                new Category { CategoryId = 7, Name = "Hats", DisplayOrder = 7 },
                new Category { CategoryId = 8, Name = "Headbands - Wristbands", DisplayOrder = 8 },
                new Category { CategoryId = 9, Name = "Hoodies", DisplayOrder = 9 },
                new Category { CategoryId = 10,Name = "Mugs & Cups", DisplayOrder = 10 }, //ok
                new Category { CategoryId = 11, Name = "ΝΒΑ Jerseys", DisplayOrder = 11 },
                new Category { CategoryId = 12, Name = "ΝΒΑ Retro Jerseys", DisplayOrder = 12 },
                new Category { CategoryId = 13,Name = "Shoes", DisplayOrder = 13},
                new Category { CategoryId = 14,Name = "Socks", DisplayOrder = 14 },
                new Category { CategoryId = 15,Name = "Stickers", DisplayOrder = 15} // ok
                
                );

            modelBuilder.Entity<Product>().HasData(
                new Product // Cups
                {
                    ProductId = 1,
                    Name = "Nba Boston Celtics Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-boston-celtics.jpg"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Nba Milwaukee Bucks Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-bucks.jpg"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nba Chicago Bulls Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-bulls.jpg"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nba Los Angeles Lakers Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-la-lakers (1).jpg"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Nba Los Angeles Lakers Cup 2",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-la-lakers.jpg"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Nba Logo Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 5,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-logo.jpg"
                },
                new Product // Air Pumps
                {
                    ProductId = 7,
                    Name = "Jordan Essential Ball Pump Intl",
                    Description = "Quickly inflate your favorite ball with the Jordan Essentials Ball Pump. Its compact design makes it easy to carry, and ideal for supplementing the ball air.",
                    Price = 19.99,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Jordan Essential Ball Pump Intl.jpg"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Nike Essential Ball Pump Intl",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 16.99,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Nike Essential Ball Pump Intl.jpg"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Nike Hyperspeed Ball Pump Intl Swoosh",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 24.50,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Nike Hyperspeed Ball Pump Intl Swoosh.jpg"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Spalding 12' Dual Action Power Pump",
                    Description = "The Spalding dual action power pump comes with an attached extension hose. The 12” pump fits all types of valves (includes two different sized needles) and pumps air by pushing and pulling action.",
                    Price = 18.00,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Spalding 12' Dual Action Power Pump.jpg"
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Wilson Nba Authentic Aluminum Pump",
                    Description = "Dual action Aluminium pump with durable extension hose.",
                    Price = 21.90,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Wilson Nba Authentic Aluminum Pump.jpg"
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 1,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Arm Sleeves
                {
                    ProductId = 23,
                    Name = "Jordan Unisex Shooter Sleeves",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 61.99,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Jordan Unisex Shooter Sleeves.jpg"
                },
                new Product
                {
                    ProductId = 24,
                    Name = "COMPRESSPORT Armforce Ultralight",
                    Description = "If you're wondering why you need these COMPRESSPORT Armforce Ultralight Sleeves if you're doing your favorite sports when the weather gets colder, the answer is to provide you with the thermoregulation you need when exposed to cold air. Featuring gentle compression properties, they precisely target core muscles for stimulated blood flow and support. For running, cycling or hiking these sleeves will hug your hands while protecting and keeping them warm.",
                    Price = 28.00,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\COMPRESSPORT Armforce Ultralight.jpg"
                },
                new Product
                {
                    ProductId = 25,
                    Name = "Nike Pro Elite SLeeves 2.0 ",
                    Description = "Pro Elite Sleeves 2.0, are made with Dri-FIT technology removing sweat for a dry and comfortable feel. Their preformed construction ensures enhanced mobility, while flat seams eliminate friction and irritation.",
                    Price = 29.90,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Nike Pro Elite SLeeves 2.0.jpg"
                },
                new Product
                {
                    ProductId = 26,
                    Name = "Nike Pro Elbow Sleeve 3.0",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 22.95,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Nike Pro Elbow Sleeve 3.0.jpg"
                },
                new Product
                {
                    ProductId = 27,
                    Name = "Nike Pro Ankle Sleeve 3.0",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 21.99,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Nike Pro Ankle Sleeve 3.0.jpg"
                },
                new Product
                {
                    ProductId = 28,
                    Name = "Nike NBA 2.0 Basketball Shooter Sleeve",
                    Description = "Utilised by the best in the game to improve performance, these form fitting sleeves provide superior support and protection. The compression fit allows a wide range of motion and muscle support. The Dri-FIT fabric wicks moisture away for comfort.Sold in pairs",
                    Price = 34.50,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Jordan Unisex Shooter Sleeves.jpg"
                },
                new Product
                {
                    ProductId = 29,
                    Name = "Mcdavid Hex Shooter Arm SLeeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 30.00,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Mcdavid Hex Shooter Arm SLeeve.jpg"
                },
                new Product
                {
                    ProductId = 30,
                    Name = "Mcdavid Power Shooter Arm SLeeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 27.99,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\Mcdavid Power Shooter Arm SLeeve.jpg"
                },
                new Product
                {
                    ProductId = 31,
                    Name = "MCDAVID Elite Compression Arm Sleeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 24.99,
                    CategoryId = 2,
                    ImageUrl = @"\images\products\MCDAVID Elite Compression Arm Sleeve.jpg"
                },
                new Product // Balls
                {
                    ProductId = 32,
                    Name = "Nike Playground 8P 2.0 G Antetokounmpo Deflated",
                    Description = "Nike Playground 8P 2.0 G Antetokounmpo Deflated",
                    Price = 33.50,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg"
                },
                new Product 
                {
                    ProductId = 33,
                    Name = "SKLZ Lightweight Control Basketball Ball",
                    Description = "The SKLZ Control basketball is the perfect training ball to help athletes improve their dribbling skills. It is made of high quality synthetic leather for indoor and outdoor training.",
                    Price = 39.90,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\SKLZ Lightweight Control Basketball Ball.jpg"
                },
                new Product
                {
                    ProductId = 34,
                    Name = "Nike All Court 8P Z Williamson Deflated",
                    Description = "Nike All Court 8P Z Williamson Deflated",
                    Price = 51.50,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike All Court 8P Z Williamson Deflated.jpg"
                },
                new Product
                {
                    ProductId = 35,
                    Name = "Nike Basketball 8P Energy Deflated",
                    Description = "Nike Basketball 8P Energy Deflated",
                    Price = 57.15,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Basketball 8P Energy Deflated.jpg"
                },
                new Product
                {
                    ProductId = 36,
                    Name = "Nike Elite Tournament 8P Deflated",
                    Description = "Nike Elite Tournament 8P Deflated",
                    Price = 68.90,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Elite Tournament 8P Deflated.jpg"
                },
                new Product
                {
                    ProductId = 37,
                    Name = "Wilson Nba Official Game Ball Bskt Retail",
                    Description = "Wilson Nba Official Game Ball Bskt Retail",
                    Price = 259,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Wilson Nba Official Game Ball Bskt Retail.jpg"
                },
                new Product
                {
                    ProductId = 38,
                    Name = "Nike Championship 8P Deflated",
                    Description = "Nike Championship 8P Deflated",
                    Price = 104,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Championship 8P Deflated.jpg"
                },
                new Product
                {
                    ProductId = 39,
                    Name = "Nike Basketball 8P Prm Energy Deflated",
                    Description = "Nike Basketball 8P Prm Energy Deflated",
                    Price = 57.51,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg"
                },
                new Product
                {
                    ProductId = 40,
                    Name = "Nike Skills",
                    Description = "Nike Skills",
                    Price = 13.50,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Skills.jpg"
                },
                new Product
                {
                    ProductId = 41,
                    Name = "Nike Everyday All Court 8P Graphic Deflated",
                    Description = "Nike Everyday All Court 8P Graphic Deflated",
                    Price = 39.90,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Everyday All Court 8P Graphic Deflated.jpg"
                },
                new Product
                {
                    ProductId = 42,
                    Name = "Nike Ultimate 2.0 8P Graphic Deflated",
                    Description = "Nike Ultimate 2.0 8P Graphic Deflated",
                    Price = 44.90,
                    CategoryId = 3,
                    ImageUrl = @"\images\products\Nike Ultimate 2.0 8P Graphic Deflated.jpg"
                },
                
                new Product // Baskets
                {
                    ProductId = 43,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product 
                {
                    ProductId = 44,
                    Name = "Wilson Nba Team Mini Hoop Bro Nets",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson Nba Team Mini Hoop Bro Nets.jpg"
                },
                new Product
                {
                    ProductId = 45,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 46,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 47,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 48,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 49,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 50,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 51,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 52,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 53,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 4,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product // Basketball Nets
                {
                    ProductId = 54,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 5,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Beanies
                {
                    ProductId = 64,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 6,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Hats
                {
                    ProductId = 74,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 7,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Headbands - Wristbands
                {
                    ProductId = 84,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 8,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Hoodies
                {
                    ProductId = 94,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 9,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // ΝΒΑ Jerseys
                {
                    ProductId = 104,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // ΝΒΑ Retro Jerseys
                {
                    ProductId = 114,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Shoes
                {
                    ProductId = 124,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Socks
                {
                    ProductId =134 ,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product  //stickers
                {
                    ProductId = 13,
                    Name = "NBA Brooklyn Nets Stickers",
                    Description = "A pack of two stickers featuring your favourite NBA team!",
                    Price = 0.90,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Back Me Up NBA Brooklyn Nets Stickers.jpg"
                },
                 new Product 
                 {
                     ProductId = 14,
                     Name = "NBA Chicago Bulls Stickers",
                     Description = "A pack of two stickers featuring your favourite NBA team!",
                     Price = 0.90,
                     CategoryId = 15,
                     ImageUrl = @"\images\products\Back Me Up NBA Chicago Bulls Stickers.png" 
                 },
                  new Product 
                  {
                      ProductId = 15,
                      Name = "NBA Dallas Mavericks Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up NBA Dallas Mavericks Stickers.png"  
                  },
                  new Product
                  {
                      ProductId = 16,
                      Name = "NBA Golden State Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up NBA Golden State Stickers.jpg"
                  },
                  new Product
                  {
                      ProductId = 17,
                      Name = "NBA Milwauke Bucks Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up NBA Milwauke Bucks Stickers.png" 
                  },
                  new Product
                  {
                      ProductId = 18,
                      Name = "NBA Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up NBA Stickers.jpg"
                  },
                  new Product
                  {
                      ProductId = 19,
                      Name = "NBA Phoenix Suns Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up Phoenix Suns Stickers.jpg"
                  },
                  new Product
                  {
                      ProductId = 20,
                      Name = "Nba Boston Celtics Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up Pvc Stickers Nba Boston Celtics.jpg"
                  },
                  new Product
                  {
                      ProductId =21,
                      Name = "NBA New York Knicks Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up Pvc Stickers Ny Knics.jpg"
                  },
                  new Product
                  {
                      ProductId = 22,
                      Name = "NBA Los Angeles Lakers Stickers",
                      Description = "A pack of two stickers featuring your favourite NBA team!",
                      Price = 0.90,
                      CategoryId = 15,
                      ImageUrl = @"\images\products\Back Me Up NBA Los Angeles Lakers Stickers.jpg"
                  }
                );
        }
    }
}


