using TheBuzzerBeater.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;




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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define categories
            var categories = new List<Category>
                {
                    new Category { CategoryId = 1, Name = "Jerseys & Apparel", DisplayOrder = 1,ImageUrl = @"\images\site\Jerseys.png" },
                    new Category { CategoryId = 2, Name = "Footwear", DisplayOrder = 2,ImageUrl = @"\images\site\Footwear.png" },
                    new Category { CategoryId = 3, Name = "Basketball Equipment", DisplayOrder = 3,ImageUrl = @"\images\site\Equipment.png" },
                    new Category { CategoryId = 4, Name = "Accessories", DisplayOrder = 4 ,ImageUrl = @"\images\site\Accessories.png"},
                    new Category { CategoryId = 5, Name = "Sales/Clearance", DisplayOrder = 5,ImageUrl = @"\images\site\Clearance.png" }
                };

            // Add subcategories
            var subcategories = new List<Category>
            {
                new Category { CategoryId = 10, Name = "Air Pumps", DisplayOrder = 1, ParentCategoryId = 3 }, //ok
                new Category { CategoryId = 11, Name = "Arm Sleeves", DisplayOrder = 2 , ParentCategoryId = 3}, //check
                new Category { CategoryId = 12, Name = "Balls", DisplayOrder = 3, ParentCategoryId = 3 }, //check
                new Category { CategoryId = 13, Name = "Basket", DisplayOrder = 4, ParentCategoryId = 3 },//check
                new Category { CategoryId = 14, Name = "Basketball Nets", DisplayOrder = 5 , ParentCategoryId = 3},//check
                new Category { CategoryId = 15, Name = "Beanies", DisplayOrder = 6, ParentCategoryId = 4 },
                new Category { CategoryId = 16, Name = "Hats", DisplayOrder = 7,ParentCategoryId = 4 },
                new Category { CategoryId = 17, Name = "Headbands - Wristbands", DisplayOrder = 8, ParentCategoryId = 3 },
                new Category { CategoryId = 18, Name = "Hoodies", DisplayOrder = 9, ParentCategoryId = 1 },
                new Category { CategoryId = 19, Name = "Mugs & Cups", DisplayOrder = 10,ParentCategoryId = 4 }, //ok
                new Category { CategoryId = 20, Name = "ΝΒΑ Jerseys", DisplayOrder = 11, ParentCategoryId = 1 },
                new Category { CategoryId = 21, Name = "ΝΒΑ Retro Jerseys", DisplayOrder = 12 , ParentCategoryId = 1},
                new Category { CategoryId = 22, Name = "Shoes", DisplayOrder = 13, ParentCategoryId = 2 },
                new Category { CategoryId = 23, Name = "Socks", DisplayOrder = 14 , ParentCategoryId = 2},
                new Category { CategoryId = 24, Name = "Stickers", DisplayOrder = 15,ParentCategoryId = 4 } // ok

            };

            // Add categories and subcategories to the modelBuilder
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Category>().HasData(subcategories);

            modelBuilder.Entity<Product>().HasData(
                new Product // Cups
                {
                    ProductId = 1,
                    Name = "Nba Boston Celtics Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-boston-celtics.jpg"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Nba Milwaukee Bucks Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-bucks.jpg"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nba Chicago Bulls Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-bulls.jpg"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nba Los Angeles Lakers Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-la-lakers (1).jpg"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Nba Los Angeles Lakers Cup 2",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 6,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-la-lakers.jpg"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Nba Logo Cup",
                    Description = "Ceramic mugs and cups with your favorite NBA team",
                    Price = 5,
                    CategoryId = 19,
                    ImageUrl = @"\images\products\back-me-up-cup-nba-logo.jpg"
                },
                new Product // Air Pumps
                {
                    ProductId = 7,
                    Name = "Jordan Essential Ball Pump Intl",
                    Description = "Quickly inflate your favorite ball with the Jordan Essentials Ball Pump. Its compact design makes it easy to carry, and ideal for supplementing the ball air.",
                    Price = 19.99,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Jordan Essential Ball Pump Intl.jpg"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Nike Essential Ball Pump Intl",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 16.99,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Nike Essential Ball Pump Intl.jpg"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Nike Hyperspeed Ball Pump Intl Swoosh",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 24.50,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Nike Hyperspeed Ball Pump Intl Swoosh.jpg"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Spalding 12' Dual Action Power Pump",
                    Description = "The Spalding dual action power pump comes with an attached extension hose. The 12” pump fits all types of valves (includes two different sized needles) and pumps air by pushing and pulling action.",
                    Price = 18.00,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Spalding 12' Dual Action Power Pump.jpg"
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Wilson Nba Authentic Aluminum Pump",
                    Description = "Dual action Aluminium pump with durable extension hose.",
                    Price = 21.90,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Wilson Nba Authentic Aluminum Pump.jpg"
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Wilson NBA DVR Pump Kit",
                    Description = "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.",
                    Price = 18.60,
                    CategoryId = 10,
                    ImageUrl = @"\images\products\Wilson NBA DVR Pump Kit.jpg"
                },
                new Product // Arm Sleeves
                {
                    ProductId = 23,
                    Name = "Jordan Unisex Shooter Sleeves",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 61.99,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Jordan Unisex Shooter Sleeves.jpg"
                },
                new Product
                {
                    ProductId = 24,
                    Name = "COMPRESSPORT Armforce Ultralight",
                    Description = "If you're wondering why you need these COMPRESSPORT Armforce Ultralight Sleeves if you're doing your favorite sports when the weather gets colder, the answer is to provide you with the thermoregulation you need when exposed to cold air. Featuring gentle compression properties, they precisely target core muscles for stimulated blood flow and support. For running, cycling or hiking these sleeves will hug your hands while protecting and keeping them warm.",
                    Price = 28.00,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\COMPRESSPORT Armforce Ultralight.jpg"
                },
                new Product
                {
                    ProductId = 25,
                    Name = "Nike Pro Elite SLeeves 2.0 ",
                    Description = "Pro Elite Sleeves 2.0, are made with Dri-FIT technology removing sweat for a dry and comfortable feel. Their preformed construction ensures enhanced mobility, while flat seams eliminate friction and irritation.",
                    Price = 29.90,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Nike Pro Elite SLeeves 2.0.jpg"
                },
                new Product
                {
                    ProductId = 26,
                    Name = "Nike Pro Elbow Sleeve 3.0",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 22.95,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Nike Pro Elbow Sleeve 3.0.jpg"
                },
                new Product
                {
                    ProductId = 27,
                    Name = "Nike Pro Ankle Sleeve 3.0",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 21.99,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Nike Pro Ankle Sleeve 3.0.jpg"
                },
                new Product
                {
                    ProductId = 28,
                    Name = "Nike NBA 2.0 Basketball Shooter Sleeve",
                    Description = "Utilised by the best in the game to improve performance, these form fitting sleeves provide superior support and protection. The compression fit allows a wide range of motion and muscle support. The Dri-FIT fabric wicks moisture away for comfort.Sold in pairs",
                    Price = 34.50,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Jordan Unisex Shooter Sleeves.jpg"
                },
                new Product
                {
                    ProductId = 29,
                    Name = "Mcdavid Hex Shooter Arm SLeeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 30.00,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Mcdavid Hex Shooter Arm SLeeve.jpg"
                },
                new Product
                {
                    ProductId = 30,
                    Name = "Mcdavid Power Shooter Arm SLeeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 27.99,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\Mcdavid Power Shooter Arm SLeeve.jpg"
                },
                new Product
                {
                    ProductId = 31,
                    Name = "MCDAVID Elite Compression Arm Sleeve",
                    Description = "Compressive Basketball Shooter Sleeves for optimal support on every shot.",
                    Price = 24.99,
                    CategoryId = 11,
                    ImageUrl = @"\images\products\MCDAVID Elite Compression Arm Sleeve.jpg"
                },
                new Product // Balls
                {
                    ProductId = 32,
                    Name = "Nike Playground 8P 2.0 G Antetokounmpo Deflated Basketball",
                    Description = "Nike Playground 8P 2.0 G Antetokounmpo Deflated",
                    Price = 33.50,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg"
                },
                new Product
                {
                    ProductId = 33,
                    Name = "SKLZ Lightweight Control Basketball ",
                    Description = "The SKLZ Control basketball is the perfect training ball to help athletes improve their dribbling skills. It is made of high quality synthetic leather for indoor and outdoor training.",
                    Price = 39.90,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\SKLZ Lightweight Control Basketball Ball.jpg"
                },
                new Product
                {
                    ProductId = 34,
                    Name = "Nike All Court 8P Z Williamson Deflated Basketball",
                    Description = "Nike All Court 8P Z Williamson Deflated",
                    Price = 51.50,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike All Court 8P Z Williamson Deflated.jpg"
                },
                new Product
                {
                    ProductId = 35,
                    Name = "Nike Basketball 8P Energy Deflated ",
                    Description = "Nike Basketball 8P Energy Deflated",
                    Price = 57.15,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Basketball 8P Energy Deflated.jpg"
                },
                new Product
                {
                    ProductId = 36,
                    Name = "Nike Elite Tournament 8P Deflated Basketball",
                    Description = "Nike Elite Tournament 8P Deflated",
                    Price = 68.90,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Elite Tournament 8P Deflated.jpg"
                },
                new Product
                {
                    ProductId = 37,
                    Name = "Wilson Nba Official Game Basketball Retail",
                    Description = "Wilson Nba Official Game Ball Bskt Retail",
                    Price = 259,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Wilson Nba Official Game Ball Bskt Retail.jpg"
                },
                new Product
                {
                    ProductId = 38,
                    Name = "Nike Championship 8P Deflated Basketball",
                    Description = "Nike Championship 8P Deflated",
                    Price = 104,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Championship 8P Deflated.jpg"
                },
                new Product
                {
                    ProductId = 39,
                    Name = "Nike Basketball 8P Prm Energy Deflated",
                    Description = "Nike Basketball 8P Prm Energy Deflated",
                    Price = 57.51,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Basketball 8P Prm Energy Deflated.jpg"
                },
                new Product
                {
                    ProductId = 40,
                    Name = "Nike Skills Basketball",
                    Description = "Nike Skills",
                    Price = 13.50,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Skills.jpg"
                },
                new Product
                {
                    ProductId = 41,
                    Name = "Nike Everyday All Court 8P Graphic Deflated Basketball",
                    Description = "Nike Everyday All Court 8P Graphic Deflated",
                    Price = 39.90,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Everyday All Court 8P Graphic Deflated.jpg"
                },
                new Product
                {
                    ProductId = 42,
                    Name = "Nike Ultimate 2.0 8P Graphic Deflated Basketball",
                    Description = "Nike Ultimate 2.0 8P Graphic Deflated",
                    Price = 44.90,
                    CategoryId = 12,
                    ImageUrl = @"\images\products\Nike Ultimate 2.0 8P Graphic Deflated.jpg"
                },

                new Product // Baskets
                {
                    ProductId = 43,
                    Name = "Wilson NBA Milwaukee Bucks Mini Hoop",
                    Description = "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.",
                    Price = 27.40,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Wilson NBA Milwaukee Bucks Mini Hoop.jpg"
                },
                new Product
                {
                    ProductId = 44,
                    Name = "Amila Basketball Dashboard 16Mm",
                    Description = "Basketball Dashboard set",
                    Price = 115.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Basketball Dashboard 16Mm.jpg"
                },
                new Product
                {
                    ProductId = 45,
                    Name = "Amila Basketball With Hoop Net 2.27-3.05M",
                    Description = "Amila Basketball With Hoop Net 2.27-3.05M",
                    Price = 279.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Basketball With Hoop Net 2.27-3.05M.jpg"
                },
                new Product
                {
                    ProductId = 46,
                    Name = "Amila Basket Semi-Professional, Thickness 3.0Mm.jpg",
                    Description = "Amila handheld basket with adjustable height for family play. Ideal for indoor and outdoor use. Dashboard made of durable polycarbonate material with steel edging. The vinyl base is filled with water or sand for guaranteed stability in play.",
                    Price = 374.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Basket Semi-Professional, Thickness 3.0Mm.jpg"
                },
                new Product
                {
                    ProductId = 47,
                    Name = "SKLZ Pro Mini Hoop System",
                    Description = "SKLZ Pro Mini Hoop System",
                    Price = 219.95,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\SKLZ Pro Mini Hoop System.jpg"
                },
                new Product
                {
                    ProductId = 48,
                    Name = "Spalding 2015 Highlight Portable 42'' Acrylic",
                    Description = "Portable basketball from the Highlight series of Spalding. With acrylic board width 42 '' and variable height from 2.28 to 3.05 meters so that both the youngest and the oldest basketball fans can enjoy the game!",
                    Price = 435.60,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Spalding 2015 Highlight Portable 42'' Acrylic.jpg"
                },
                new Product
                {
                    ProductId = 49,
                    Name = "Amila Backboard 122 x 85 cm 49197",
                    Description = "Amila Backboard with three-colour net.",
                    Price = 219.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Backboard 122 x 85 cm 49197.jpg"
                },
                new Product
                {
                    ProductId = 50,
                    Name = "Amila Basketball Hoop with Springs & Net",
                    Description = "Amila Basketball Hoop with Springs & Net.",
                    Price = 67.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Basketball Hoop with Springs & Net.jpg"
                },
                new Product
                {
                    ProductId = 51,
                    Name = "Amila Basketball Hoop",
                    Description = "Basket wreath with steel tube and spring for pressure absorption from ball hitting and hanging by players. Its diameter is 45cm and includes net in the package. Suitable for every dashboard and basketball to play on the court, garden or cottage.",
                    Price = 64.90,
                    CategoryId = 13,
                    ImageUrl = @"\images\products\Amila Basketball Hoop.jpg"
                },
                new Product // Basketball Nets
                {
                    ProductId = 52,
                    Name = "Wilson Nba Drv Recreational Basketball Net",
                    Description = "Red, white and blue throwback design.Fits all standard size rims.Suitable for indoor and outdoor courts",
                    Price = 10.90,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Wilson Nba Drv Recreational Basketball Net.jpg"
                },
                new Product
                {
                    ProductId = 53,
                    Name = "Amila Basketball Net",
                    Description = "Amila Basketball Net.One piece per package.",
                    Price = 6.90,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Amila Basketball Net.jpg"
                },
                new Product
                {
                    ProductId = 54,
                    Name = "Spalding All Weather Basketball Net",
                    Description = "Red, white and blue throwback design.Fits all standard size rims.Suitable for indoor and outdoor courts",
                    Price = 10.90,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Spalding All Weather Basketball Net.jpg"
                },
                new Product
                {
                    ProductId = 55,
                    Name = "Amila Basketball Net 45cm",
                    Description = "This metal wreath by Amila weighs 590 g and is ideal for outdoor use.",
                    Price = 12.90,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Amila Basketball Net 45cm.jpg"
                },
                new Product
                {
                    ProductId = 56,
                    Name = "Amila Basketball Net 1 piece 0.4cm",
                    Description = "Professional and durable basketball net with 12 hooks, ideal for a unique hooping game.",
                    Price = 9.90,
                    CategoryId = 14,
                    ImageUrl = @"\images\products\Amila Basketball Net 1 piece 0.4cm.jpg"
                },
                new Product // Beanies
                {
                    ProductId = 57,
                    Name = "ΝBA Los Angeles Lakers Men's Beanie",
                    Description = "New Era design & Lakers.Regular fit.100% acryllic",
                    Price = 30.00,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\ΝBA Los Angeles Lakers Men's Beanie.jpg"
                },
                new Product
                {
                    ProductId = 58,
                    Name = "ΝBA Chicago Bulls Men's Beanie",
                    Description = "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.",
                    Price = 33.00,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\ΝBA Chicago Bulls Men's Beanie.jpg"
                },
                new Product
                {
                    ProductId = 59,
                    Name = "Nba21 City Off Knit Milbuc Men's Beanie",
                    Description = "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.",
                    Price = 33.00,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Nba21 City Off Knit Milbuc Men's Beanie.jpg"
                },
                new Product
                {
                    ProductId = 60,
                    Name = "Nba21 City Off Knit Loslak Men's Beanie",
                    Description = "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.",
                    Price = 33.00,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Nba21 City Off Knit Loslak Men's Beanie.jpg"
                },
                new Product
                {
                    ProductId = 61,
                    Name = "Nba21 City Alt Knit Miami Heat Men's Beanie",
                    Description = "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.",
                    Price = 33.00,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Nba21 City Alt Knit Miami Heat Men's Beanie.jpg"
                },
                new Product
                {
                    ProductId = 62,
                    Name = "Jordan Utility Metal Unisex Beanie",
                    Description = "Low temperatures limit the range of your daily activities. But this is not the case for Jordan. The heart of her new collection is the comfort and the cozy vibes that we all love so much and want every moment of our daily lives. Indulge fearlessly in every activity without being limited by the cold!",
                    Price = 35.90,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Jordan Utility Metal Unisex Beanie.jpg"
                },
                new Product
                {
                    ProductId = 63,
                    Name = "Jordan Utility Metal Unisex Beanie Red",
                    Description = "Low temperatures limit the range of your daily activities. But this is not the case for Jordan. The heart of her new collection is the comfort and the cozy vibes that we all love so much and want every moment of our daily lives. Indulge fearlessly in every activity without being limited by the cold!",
                    Price = 35.90,
                    CategoryId = 15,
                    ImageUrl = @"\images\products\Jordan Utility Metal Unisex Beanie Red.jpg"
                },
                new Product // Hats
                {
                    ProductId = 64,
                    Name = "Jordan Clc99 Air Men's Tracker Cap",
                    Description = "Complete each athleisure outfit with a cap! This cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style.",
                    Price = 34.60,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Clc99 Air Men's Tracker Cap.jpg"
                },
                new Product
                {
                    ProductId = 65,
                    Name = "Jordan Pro Jumpman Snapback Unisex Hat",
                    Description = "This Jordan Pro Jumpman Snapback hat takes your style to the next level and features an embroidered Jumpman design on the front. Top quality fabric and design with back pleats ensure a classic look.",
                    Price = 24.90,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Pro Jumpman Snapback Unisex Hat.jpg"
                },
                new Product
                {
                    ProductId = 66,
                    Name = "Jordan Pro Jumpman Classics Cap",
                    Description = "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.",
                    Price = 26.99,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Pro Jumpman Classics Cap.jpg"
                },
                new Product
                {
                    ProductId = 67,
                    Name = "NBA Finals 950 Denver Nuggets",
                    Description = "NEW ERA NBA Finals 950 Denver Nuggets",
                    Price = 40.00,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\NBA Finals 950 Dennug.jpg"
                },
                new Product
                {
                    ProductId = 68,
                    Name = "NBA Finals 950 Miami Heat",
                    Description = "NEW ERA NBA Finals 950 Miami Heat",
                    Price = 40.00,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\NBA Finals 950 Miahea.jpg"
                },
                new Product
                {
                    ProductId = 69,
                    Name = "Jordan Pro Jumpman Classics Cap Black",
                    Description = "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.",
                    Price = 26.99,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Pro Jumpman Classics Cap Black.jpg"
                },
                new Product
                {
                    ProductId = 70,
                    Name = "Jordan Pro Jumpman Classics Cap Mint",
                    Description = "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.",
                    Price = 26.99,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Pro Jumpman Classics Cap Mint.jpg"
                },
                new Product
                {
                    ProductId = 71,
                    Name = "Jordan Pro Jumpman Classics Cap Orange",
                    Description = "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.",
                    Price = 26.99,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Pro Jumpman Classics Cap Orange.jpg"
                },
                new Product
                {
                    ProductId = 72,
                    Name = "Jordan Jumpman Washed Bucket Hat",
                    Description = "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.",
                    Price = 34.99,
                    CategoryId = 16,
                    ImageUrl = @"\images\products\Jordan Jumpman Washed Bucket Hat.jpg"
                },
                 new Product
                 {
                     ProductId = 73,
                     Name = "Jordan Jumpman Washed Bucket Hat White",
                     Description = "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.",
                     Price = 34.99,
                     CategoryId = 16,
                     ImageUrl = @"\images\products\Jordan Jumpman Washed Bucket Hat White.jpg"
                 },
                  new Product
                  {
                      ProductId = 74,
                      Name = "Jordan Jumpman Washed Bucket Hat Red",
                      Description = "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.",
                      Price = 34.99,
                      CategoryId = 16,
                      ImageUrl = @"\images\products\Jordan Jumpman Washed Bucket Hat Red.jpg"
                  },
                new Product // Headbands - Wristbands
                {
                    ProductId = 75,
                    Name = "Nike Pro Wrist And Thumb Wrap 3.1",
                    Description = "Nike Pro Wrist And Thumb Wrap 3.1",
                    Price = 21.99,
                    CategoryId = 17,
                    ImageUrl = @"\images\products\Nike Pro Wrist And Thumb Wrap.jpg"
                },
                new Product
                {
                    ProductId = 76,
                    Name = "Nike NBA Unisex Headband White",
                    Description = "The Nike NBA Basketball Headband features sweat-wicking fabric to help keep your head dry and comfortable for optimal performance on the court.Dri-FIT Technology helps keep you dry and comfortable.Breathable knit provides optimal airflow",
                    Price = 21.90,
                    CategoryId = 17,
                    ImageUrl = @"\images\products\Nike NBA Unisex Headband White.jpg"
                },
                new Product
                {
                    ProductId = 77,
                    Name = "Nike NBA Unisex Headband Black",
                    Description = "The Nike NBA Basketball Headband features sweat-wicking fabric to help keep your head dry and comfortable for optimal performance on the court.Dri-FIT Technology helps keep you dry and comfortable.Breathable knit provides optimal airflow",
                    Price = 21.90,
                    CategoryId = 17,
                    ImageUrl = @"\images\products\Nike NBA Unisex Headband Black.jpg"
                },
                 new Product
                 {
                     ProductId = 78,
                     Name = "Jordan Jumpman Unisex Headband Black",
                     Description = "The Jordan Jumpman Headband helps keep your sweat away while playing the game. Made of soft materials, this headband will keep you dry.Lasting Comfort. Secure Fit.\r\n",
                     Price = 17.50,
                     CategoryId = 17,
                     ImageUrl = @"\images\products\Jordan Jumpman Unisex Headband Black.jpg"
                 },
                  new Product
                  {
                      ProductId = 79,
                      Name = "Jordan Jumpman Unisex Headband",
                      Description = "The Jordan Jumpman Headband helps keep your sweat away while playing the game. Made of soft materials, this headband will keep you dry.Lasting Comfort. Secure Fit.",
                      Price = 17.50,
                      CategoryId = 17,
                      ImageUrl = @"\images\products\Jordan Jumpman Unisex Headband.jpg"
                  },
                   new Product
                   {
                       ProductId = 80,
                       Name = "Jordan Jumpman Wristbands",
                       Description = "This Jordan Jumpman Wristbands will keep sweat away from your skin! It’s made from a soft fabric that absorbs sweat and reduces distractions to get absolute concentration in the game.",
                       Price = 18.90,
                       CategoryId = 17,
                       ImageUrl = @"\images\products\Jordan Jumpman Wristbands.jpg"
                   },
                   new Product
                   {
                       ProductId = 81,
                       Name = "Jordan Jumpman Wristbands Black",
                       Description = "This Jordan Jumpman Wristbands will keep sweat away from your skin! It’s made from a soft fabric that absorbs sweat and reduces distractions to get absolute concentration in the game.",
                       Price = 18.90,
                       CategoryId = 17,
                       ImageUrl = @"\images\products\Jordan Jumpman Wristbands Black.jpg"
                   },
                    new Product
                    {
                        ProductId = 82,
                        Name = "Nike Wristbands Nba",
                        Description = "Flaunt your allegiance to the NBA® when you sport the Nike NBA® On-Court Wristbands. The breathable, moisture-wicking bands are made of comfortable nylon fabric to keep you cool and dry during the most intense games.",
                        Price = 24.90,
                        CategoryId = 17,
                        ImageUrl = @"\images\products\Nike Wristbands Nba.jpg"
                    },
                    new Product
                    {
                        ProductId = 83,
                        Name = "Nike Wristbands Nba Black",
                        Description = "Flaunt your allegiance to the NBA® when you sport the Nike NBA® On-Court Wristbands. The breathable, moisture-wicking bands are made of comfortable nylon fabric to keep you cool and dry during the most intense games.",
                        Price = 24.90,
                        CategoryId = 17,
                        ImageUrl = @"\images\products\Nike Wristbands Nba Black.jpg"
                    },
                    new Product // Hoodies
                    {
                        ProductId = 84,
                        Name = "Jordan NBA Charlotte Hornets Club Men's Hoodie",
                        Description = "Show off your pride in your team wherever you go! This is the ideal way to keep warm and declare your allegiance when you're off the court or warming up.",
                        Price = 64.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Jordan NBA Charlotte Hornets Club Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 85,
                        Name = "Jordan NBA Chicago Bulls Courtside Statement Edition Men's Hoodie",
                        Description = "Show off your pride in your team wherever you go! This is the ideal way to keep warm and declare your allegiance when you're off the court or warming up.",
                        Price = 64.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Jordan NBA Chicago Bulls Courtside Statement Edition Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 86,
                        Name = "Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie",
                        Description = "Layer up in this soft and roomy Milwaukee Bucks fleece hoodie to shrug off the chill in cooler temps. Displaying proud graphics in squad colors, it pays tribute to your favorite team.",
                        Price = 65.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 87,
                        Name = "Nike Dri-FIT NBA Brooklyn Nets Spotlight Men's Hoodie",
                        Description = "Designed for players to wear at practice, the Brooklyn Nets Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.",
                        Price = 65.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike Dri-FIT NBA Brooklyn Nets Spotlight Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 88,
                        Name = "Nike NBA Boston Celtics Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Boston Celtics Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Boston Celtics Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 89,
                        Name = "Nike NBA Dri-FIT Los Angeles Lakers Spotlight Men's Hoodie",
                        Description = "Designed for players to wear at practice, the Los Angeles Lakers Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.",
                        Price = 65.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Dri-FIT Los Angeles Lakers Spotlight Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 90,
                        Name = "Nike NBA Golden State Wariors Club Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Golden State Wariors Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Golden State Wariors Club Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 91,
                        Name = "Nike NBA Los Angeles Lakers Club Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Los Angeles Lakers Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Los Angeles Lakers Club Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 92,
                        Name = "Nike Team 31 Club Fleece Mens Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Logo Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 50.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike Team 31 Club Fleece Mens Hoodie.png"
                    },
                    new Product
                    {
                        ProductId = 93,
                        Name = "Nike NBA Brooklyn Nets Club Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Brooklyn Nets Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Brooklyn Nets Club Men's Hoodie.png"
                    },
                    new Product
                    {
                        ProductId = 94,
                        Name = "Nike NBA Chicago Bulls Club Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Chicago Bulls Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBAChicago Bulls Club Men's Hoodie.jpg"
                    },
                    new Product
                    {
                        ProductId = 95,
                        Name = "Nike Dri FIT NBA Golden State Warriors Men's Hoodie",
                        Description = "Designed for players to wear at practice, the Golden State Warriors Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.",
                        Price = 65.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike Dri FIT NBA Golden State Warriors Men's Hoodie.png"
                    },
                    new Product
                    {
                        ProductId = 96,
                        Name = "Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie",
                        Description = "Designed for players to wear at practice, the Milwaukee Bucks Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.",
                        Price = 65.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie.png"
                    },
                    new Product
                    {
                        ProductId = 97,
                        Name = "Nike NBA Milwaukee Bucks Club Men's Hoodie",
                        Description = "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Milwaukee Bucks Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant",
                        Price = 59.00,
                        CategoryId = 18,
                        ImageUrl = @"\images\products\Nike NBA Milwaukee Bucks Club Men's Hoodie.png"
                    },
                    new Product // ΝΒΑ Jerseys
                    {
                        ProductId = 148,
                        Name = "Atlanta Hawks Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Atlanta Hawks Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 149,
                        Name = "Boston Celtics Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Boston Celtics Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 150,
                        Name = "Brooklyn Nets Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Brooklyn Nets Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 151,
                        Name = "Charlotte Hornets Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Charlotte Hornets Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 152,
                        Name = "Chicago Bulls Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Chicago Bulls Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 153,
                        Name = "Cleveland Cavaliers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Cleveland Cavaliers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 154,
                        Name = "Dallas Mavericks Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Dallas Mavericks Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 155,
                        Name = "Denver Nuggets Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Denver Nuggets Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 156,
                        Name = "Detroit Pistons Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Detroit Pistons Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 157,
                        Name = "Golden State Warriors Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Golden State Warriors Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 158,
                        Name = "Houston Rockets Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Houston Rockets Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 159,
                        Name = "Indiana Pacers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Indiana Pacers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 160,
                        Name = "LA Clippers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\LA Clippers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 161,
                        Name = "Los Angeles Lakers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Los Angeles Lakers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 162,
                        Name = "Memphis Grizzlies Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Memphis Grizzlies Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 163,
                        Name = "Miami Heat Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Miami Heat Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 164,
                        Name = "Milwaukee Bucks Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Milwaukee Bucks Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 165,
                        Name = "Minnesota Timberwolves Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Minnesota Timberwolves Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 166,
                        Name = "New Orleans Pelicans Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\New Orleans Pelicans Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 167,
                        Name = "New York Knicks Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\New York Knicks Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 168,
                        Name = "Oklahoma City Thunder Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Oklahoma City Thunder Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 169,
                        Name = "Orlando Magic Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Orlando Magic Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 170,
                        Name = "Philadelphia 76ers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Philadelphia 76ers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 171,
                        Name = "Phoenix Suns Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Phoenix Suns Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 172,
                        Name = "Portland Trail Blazers Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Portland Trail Blazers Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 173,
                        Name = "Sacramento Kings Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Sacramento Kings Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 174,
                        Name = "San Antonio Spurs Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\San Antonio Spurs Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 175,
                        Name = "Toronto Raptors Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Toronto Raptors Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 176,
                        Name = "Utah Jazz Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Utah Jazz Official Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 177,
                        Name = "Washington Wizards Official Jersey",
                        Description = "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit",
                        Price = 96.90,
                        CategoryId = 20,
                        ImageUrl = @"\images\products\Washington Wizards Official Jersey.png"
                    },
                    new Product // ΝΒΑ Retro Jerseys
                    {
                        ProductId = 100,
                        Name = "Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey",
                        Description = "Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product 
                    {
                        ProductId = 101,
                        Name = "Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey",
                        Description = "Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey.jpg"
                    },
                    new Product
                    {
                        ProductId = 102,
                        Name = "Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness",
                        Description = "Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness.png"
                    },
                    new Product
                    {
                        ProductId = 103,
                        Name = "Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey",
                        Description = "Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 104,
                        Name = "Dennis Rodman Chicago Bulls Mitchell & Ness NBA Jersey",
                        Description = "Dennis Rodman Chicago Bulls Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Dennis Rodman Chicago Bulls Mitchell & Ness NBA  Jersey.jpg"
                    },
                    new Product
                    {
                        ProductId = 105,
                        Name = "Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey",
                        Description = "Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 106,
                        Name = "Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey",
                        Description = "Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 107,
                        Name = "Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey",
                        Description = "Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 108,
                        Name = "Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey",
                        Description = "Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 109,
                        Name = "Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey",
                        Description = "Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 110,
                        Name = "Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey",
                        Description = "Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 111,
                        Name = "Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA Jersey",
                        Description = "Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA  Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 112,
                        Name = "Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA Jersey",
                        Description = "Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA  Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 113,
                        Name = "Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA Jersey",
                        Description = "Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA  Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA  Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 114,
                        Name = "Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey",
                        Description = "Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 115,
                        Name = "Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey",
                        Description = "Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 116,
                        Name = "Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey",
                        Description = "Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 117,
                        Name = "Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey",
                        Description = "Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 118,
                        Name = "Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey",
                        Description = "Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey.jpg"
                    },
                    new Product
                    {
                        ProductId = 119,
                        Name = "Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey",
                        Description = "Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product
                    {
                        ProductId = 120,
                        Name = "Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey",
                        Description = "Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey",
                        Price = 105,
                        CategoryId = 21,
                        ImageUrl = @"\images\products\Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey.png"
                    },
                    new Product // Shoes
                    {
                        ProductId = 124,
                        Name = "adidas D.O.N. Issue 4",
                        Description = "The future of basketball is all about speed, and Donovan Mitchell is as fast as they come. These signature shoes from Mitchell and adidas Basketball are built specifically to elevate the movements of one of the game's fastest, most dynamic scorers. Ultralight Lightstrike teams up with a LIGHTLOCK upper for a snug fit and a propulsion system that won't weigh you down. A unique rubber outsole is designed to generate traction where you need it most, so every hard-charging cut and head fake has total support. Mitchell's Spida logo and signature graphics provide the finishing touches.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.",
                        Price = 66.00,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\adidas D.O.N. Issue 4.jpg"
                    },
                    new Product
                    {
                        ProductId = 125,
                        Name = "adidas D.O.N. Issue 4 Red",
                        Description = "The future of basketball is all about speed, and Donovan Mitchell is as fast as they come. These signature shoes from Mitchell and adidas Basketball are built specifically to elevate the movements of one of the game's fastest, most dynamic scorers. Ultralight Lightstrike teams up with a LIGHTLOCK upper for a snug fit and a propulsion system that won't weigh you down. A unique rubber outsole is designed to generate traction where you need it most, so every hard-charging cut and head fake has total support. Mitchell's Spida logo and signature graphics provide the finishing touches.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.",
                        Price = 66.00,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\adidas D.O.N. Issue 4 Red.png"
                    },
                    new Product
                    {
                        ProductId = 126,
                        Name = "adidas Performance D.O.N. Issue 5  Men's Basketball Shoes",
                        Description = "From the first time he stepped on the court, Donovan Mitchell changed the rules of the game and continues to do so to this day. These D.O.N. Issue 5 adidas Basketball signature shoes show Spida's personal style, but also his social activity. These basketball sneakers help you dominate the game thanks to the lightweight Lightstrike midsole and unique rubber outsole with an upgraded traction pattern.",
                        Price = 86.00,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\adidas Performance D.O.N. Issue 5  Men's Basketball Shoes.png"
                    },
                    new Product
                    {
                        ProductId = 127,
                        Name = "Nike Lebron IX -King of LA- Men's Basketball Shoes",
                        Description = "It's been 10 years since the LeBron 9 made its debut and helped propel King James to a championship. Now, the model is back, ready for casual games and hitting the streets afterwards. This new colourway pairs theme-park pink with teddy-bear brown on super-soft, fluffy fabric. Gradient accents recall summer nights at the theme park. Lace up and take a step into LeBron's world.\r\n\r\n.",
                        Price = 127,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\Nike Lebron IX -King of LA- Men's Basketball Shoes.png"
                    },
                    new Product
                    {
                        ProductId = 128,
                        Name = "Under Armour Curry 3Z5 Men's Basketball Shoes",
                        Description = "Strike on court wearing the Curry 3Z5 by Under Armour. Thes basketball boots are made from lightweight breathable mesh upper featuring micro G foam midsole turning landing into explosive takeoffs.\r\n",
                        Price = 18.60,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\Under Armour Curry 3Z5 Men's Basketball Shoes.png"
                    },
                    new Product
                    {
                        ProductId = 129,
                        Name = "adidas Dame Certified Men's Basketball Shoes",
                        Description = "Whether it's in the sound booth or in the last few minutes of crunch time, Damian Lillard always brings his A-game. These adidas basketball shoes invoke Dame's his commitment to honing his craft on the hardwood and in the music studio. Bounce cushioning is soft and springy to put that pep on your step when your team needs it most.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.\r\n",
                        Price = 60.00,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\adidas Dame Certified Men's Basketball Shoes.png"
                    },
                    new Product
                    {
                        ProductId = 130,
                        Name = "adidas Dame Certified Men's Basketball Shoes Red",
                        Description = "Whether it's in the sound booth or in the last few minutes of crunch time, Damian Lillard always brings his A-game. These adidas basketball shoes invoke Dame's his commitment to honing his craft on the hardwood and in the music studio. Bounce cushioning is soft and springy to put that pep on your step when your team needs it most.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.",
                        Price = 60.00,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\adidas Dame Certified Men's Basketball Shoes Red.png"
                    },
                    new Product
                    {
                        ProductId = 131,
                        Name = "adidas Performance Dame 8 Extply Men's Basketball Shoes",
                        Description = "These basketball shoes provide exceptional durability while you won't run away from friction. Signed by Damian Lillard and adidas, they give you confidence whether you're shooting baskets or in the gym. They feature a Bounce Pro midsole that combines increased stability with lightweight, flexible cushioning as well as an inner sock construction and TPU propulsion plate. They are completed with the brand's design.\r\n",
                        Price = 130.00,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\adidas Performance Dame 8 Extply Men's Basketball Shoes.png"
                    },
                    new Product
                    {
                        ProductId = 132,
                        Name = "Nike Freak 5 ,Made in Sepolia,Men's Basketball Shoes",
                        Description = "This basketball shoe is inspired by the environment and life of John. Giannis Antetokounmpo has explosive power on the court and needs a shoe that can fully showcase his exceptional ability. The Zoom Freak 5 adopts a fast design to help it launch with amazing speed. At the same time, it is equipped with an absorption configuration to bring a bounce effect to the game. Do your thing and rush past your opponents or pull off key defensive moves like Giannis. Whatever you do, the durable rubber outsole gives you strong traction to get it done.\r\n",
                        Price = 124.99,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\Nike Freak 5 ,Made in Sepolia,Men's Basketball Shoes.jpg"
                    },
                    new Product
                    {
                        ProductId = 133,
                        Name = "Nike Zoom Freak 4 Action Grape Men's Basketball Shoes",
                        Description = "Giannis is an incessant storm of stamina and skill that keeps coming at opponents for 4 quarters or more. The forward-thinking design of his latest signature shoe helps propel you down the court in a lightweight fit that moves with you. It can handle quick changes in direction on both sides of the floor, giving you side-to-side stability and multi-directional traction as you Euro step to the hoop. This special colourway is inspired by the Greek Freak's towering power and his ability to bring his inner fire to the floor night in and night out.",
                        Price = 87.99,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\Nike Zoom Freak 4 Action Grape Men's Basketball Shoes.jpg"
                    },
                    new Product
                    {
                        ProductId = 134,
                        Name = "Nike Zoom Freak 5 Men's Basketball Shoes",
                        Description = "The Freak 5 is a basketball shoe that can tame the impressive potential of the Greek Freak. Built with technology that offers speed as well as elastic cushioning, the signature shoe of Giannis offers it all.",
                        Price = 135.00,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\Nike Zoom Freak 5 Men's Basketball Shoes.jpg"
                    },
                    new Product
                    {
                        ProductId = 135,
                        Name = "Nike KD Trey 5 X Men's Basketball Boots",
                        Description = "The KD Trey 5 X has a lightweight upper and soft support system to give you KD's airy movement while you wait for the perfect moment to get to the basket. The stable midfoot strap is suitable for non-stop scoring and helping to defend, so you can enjoy a stable feel and win all the time.\r\n",
                        Price = 95.60,
                        CategoryId = 22,
                        ImageUrl = @"\images\products\Nike KD Trey 5 X Men's Basketball Boots.png"
                    },
                     new Product
                     {
                         ProductId = 136,
                         Name = "Nike Kyrie Low 5 Men's Basketball Shoes",
                         Description = "Designed for a quick, crafty game, this shoe enables players who use their speed and multi-directional ability to stay in control while taking advantage of the separation they create.",
                         Price = 74.99,
                         CategoryId = 22,
                         ImageUrl = @"\images\products\Nike Kyrie Low 5 Men's Basketball Shoes.png"
                     },
                      new Product
                      {
                          ProductId = 137,
                          Name = "Nike LeBron Witness 8 -Cannon-Men's Basketball Boots",
                          Description = "With the LeBron Witness 8, your performance will go to the next level! Show everyone that your talent and comprehensive skills know no bounds. This sleek shoe with bold design lines provides stability during explosive movements and smooth landings at ground contact, allowing elite players like you and LeBron to jump, stop and move with power from one end of the field to the other.\r\n",
                          Price = 84.99,
                          CategoryId = 5,
                          ImageUrl = @"\images\products\Nike LeBron Witness 8 -Cannon-Men's Basketball Boots.jpg"
                      },
                    new Product // Socks
                    {
                        ProductId = 138,
                        Name = "Nike Everyday 3-Pack Men's Basketball Socks",
                        Description = "Nike Everyday 3-Pack Men's Basketball Socks",
                        Price = 17.99,
                        CategoryId = 5,
                        ImageUrl = @"\images\products\Nike Everyday 3-Pack Men's Basketball Socks.jpg"
                    },
                     new Product
                     {
                         ProductId = 139,
                         Name = "Jordan Ultimate Flight 2.0 Crew Socks",
                         Description = "Jordan Ultimate Flight 2.0 Crew",
                         Price = 17.99,
                         CategoryId = 23,
                         ImageUrl = @"\images\products\Jordan Ultimate Flight 2.0 Crew.jpg"
                     },
                      new Product
                      {
                          ProductId = 140,
                          Name = "Stance New York Knicks socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-nyk-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 141,
                          Name = "Stance Milwaukee Bucks socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-mil-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 142,
                          Name = "Stance Memphies Grizzlies socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-mem-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 143,
                          Name = "Stance Los Angeles Lakers socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-lal-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 144,
                          Name = "Stance Chicago Bulls socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-chi-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 145,
                          Name = "Stance Dallas Mavericks socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-dal-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 146,
                          Name = "Stance Denver Nuggets socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-den-ce24.jpg"
                      },
                      new Product
                      {
                          ProductId = 147,
                          Name = "Stance Golden State Warriors socks",
                          Description = "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.",
                          Price = 19.99,
                          CategoryId = 23,
                          ImageUrl = @"\images\products\stance-gsw-ce24.jpg"
                      },
                    new Product  //stickers
                    {
                        ProductId = 13,
                        Name = "NBA Brooklyn Nets Stickers",
                        Description = "A pack of two stickers featuring your favourite NBA team!",
                        Price = 0.90,
                        CategoryId = 24,
                        ImageUrl = @"\images\products\Back Me Up NBA Brooklyn Nets Stickers.jpg"
                    },
                     new Product
                     {
                         ProductId = 14,
                         Name = "NBA Chicago Bulls Stickers",
                         Description = "A pack of two stickers featuring your favourite NBA team!",
                         Price = 0.90,
                         CategoryId = 24,
                         ImageUrl = @"\images\products\Back Me Up NBA Chicago Bulls Stickers.png"
                     },
                      new Product
                      {
                          ProductId = 15,
                          Name = "NBA Dallas Mavericks Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up NBA Dallas Mavericks Stickers.png"
                      },
                      new Product
                      {
                          ProductId = 16,
                          Name = "NBA Golden State Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up NBA Golden State Stickers.jpg"
                      },
                      new Product
                      {
                          ProductId = 17,
                          Name = "NBA Milwauke Bucks Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up NBA Milwauke Bucks Stickers.png"
                      },
                      new Product
                      {
                          ProductId = 18,
                          Name = "NBA Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up NBA Stickers.jpg"
                      },
                      new Product
                      {
                          ProductId = 19,
                          Name = "NBA Phoenix Suns Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up Phoenix Suns Stickers.jpg"
                      },
                      new Product
                      {
                          ProductId = 20,
                          Name = "Nba Boston Celtics Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up Pvc Stickers Nba Boston Celtics.jpg"
                      },
                      new Product
                      {
                          ProductId = 21,
                          Name = "NBA New York Knicks Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up Pvc Stickers Ny Knics.jpg"
                      },
                      new Product
                      {
                          ProductId = 22,
                          Name = "NBA Los Angeles Lakers Stickers",
                          Description = "A pack of two stickers featuring your favourite NBA team!",
                          Price = 0.90,
                          CategoryId = 24,
                          ImageUrl = @"\images\products\Back Me Up NBA Los Angeles Lakers Stickers.jpg"
                      }
                    );
        }
    }
}


