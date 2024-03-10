using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderHeaderId);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "DisplayOrder", "ImageUrl", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, 1, "\\images\\site\\Jerseys.png", "Jerseys & Apparel", null },
                    { 2, 2, "\\images\\site\\Footwear.png", "Footwear", null },
                    { 3, 3, "\\images\\site\\Equipment.png", "Basketball Equipment", null },
                    { 4, 4, "\\images\\site\\Accessories.png", "Accessories", null },
                    { 5, 5, "\\images\\site\\Clearance.png", "Sales/Clearance", null },
                    { 10, 1, null, "Air Pumps", 3 },
                    { 11, 2, null, "Arm Sleeves", 3 },
                    { 12, 3, null, "Balls", 3 },
                    { 13, 4, null, "Basket", 3 },
                    { 14, 5, null, "Basketball Nets", 3 },
                    { 15, 6, null, "Beanies", 4 },
                    { 16, 7, null, "Hats", 4 },
                    { 17, 8, null, "Headbands - Wristbands", 3 },
                    { 18, 9, null, "Hoodies", 1 },
                    { 19, 10, null, "Mugs & Cups", 4 },
                    { 20, 11, null, "ΝΒΑ Jerseys", 1 },
                    { 21, 12, null, "ΝΒΑ Retro Jerseys", 1 },
                    { 22, 13, null, "Shoes", 2 },
                    { 23, 14, null, "Socks", 2 },
                    { 24, 15, null, "Stickers", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 124, 5, "The future of basketball is all about speed, and Donovan Mitchell is as fast as they come. These signature shoes from Mitchell and adidas Basketball are built specifically to elevate the movements of one of the game's fastest, most dynamic scorers. Ultralight Lightstrike teams up with a LIGHTLOCK upper for a snug fit and a propulsion system that won't weigh you down. A unique rubber outsole is designed to generate traction where you need it most, so every hard-charging cut and head fake has total support. Mitchell's Spida logo and signature graphics provide the finishing touches.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.", "\\images\\products\\adidas D.O.N. Issue 4.jpg", "adidas D.O.N. Issue 4", 66.0 },
                    { 125, 5, "The future of basketball is all about speed, and Donovan Mitchell is as fast as they come. These signature shoes from Mitchell and adidas Basketball are built specifically to elevate the movements of one of the game's fastest, most dynamic scorers. Ultralight Lightstrike teams up with a LIGHTLOCK upper for a snug fit and a propulsion system that won't weigh you down. A unique rubber outsole is designed to generate traction where you need it most, so every hard-charging cut and head fake has total support. Mitchell's Spida logo and signature graphics provide the finishing touches.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.", "\\images\\products\\adidas D.O.N. Issue 4 Red.png", "adidas D.O.N. Issue 4 Red", 66.0 },
                    { 129, 5, "Whether it's in the sound booth or in the last few minutes of crunch time, Damian Lillard always brings his A-game. These adidas basketball shoes invoke Dame's his commitment to honing his craft on the hardwood and in the music studio. Bounce cushioning is soft and springy to put that pep on your step when your team needs it most.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.\r\n", "\\images\\products\\adidas Dame Certified Men's Basketball Shoes.png", "adidas Dame Certified Men's Basketball Shoes", 60.0 },
                    { 130, 5, "Whether it's in the sound booth or in the last few minutes of crunch time, Damian Lillard always brings his A-game. These adidas basketball shoes invoke Dame's his commitment to honing his craft on the hardwood and in the music studio. Bounce cushioning is soft and springy to put that pep on your step when your team needs it most.Made in part with recycled content generated from production waste, e.g. cutting scraps, and post-consumer household waste to avoid the larger environmental impact of producing virgin content.", "\\images\\products\\adidas Dame Certified Men's Basketball Shoes Red.png", "adidas Dame Certified Men's Basketball Shoes Red", 60.0 },
                    { 133, 5, "Giannis is an incessant storm of stamina and skill that keeps coming at opponents for 4 quarters or more. The forward-thinking design of his latest signature shoe helps propel you down the court in a lightweight fit that moves with you. It can handle quick changes in direction on both sides of the floor, giving you side-to-side stability and multi-directional traction as you Euro step to the hoop. This special colourway is inspired by the Greek Freak's towering power and his ability to bring his inner fire to the floor night in and night out.", "\\images\\products\\Nike Zoom Freak 4 Action Grape Men's Basketball Shoes.jpg", "Nike Zoom Freak 4 Action Grape Men's Basketball Shoes", 87.989999999999995 },
                    { 137, 5, "With the LeBron Witness 8, your performance will go to the next level! Show everyone that your talent and comprehensive skills know no bounds. This sleek shoe with bold design lines provides stability during explosive movements and smooth landings at ground contact, allowing elite players like you and LeBron to jump, stop and move with power from one end of the field to the other.\r\n", "\\images\\products\\Nike LeBron Witness 8 -Cannon-Men's Basketball Boots.jpg", "Nike LeBron Witness 8 -Cannon-Men's Basketball Boots", 84.989999999999995 },
                    { 138, 5, "Nike Everyday 3-Pack Men's Basketball Socks", "\\images\\products\\Nike Everyday 3-Pack Men's Basketball Socks.jpg", "Nike Everyday 3-Pack Men's Basketball Socks", 17.989999999999998 },
                    { 1, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-boston-celtics.jpg", "Nba Boston Celtics Cup", 6.0 },
                    { 2, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-bucks.jpg", "Nba Milwaukee Bucks Cup", 6.0 },
                    { 3, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-bulls.jpg", "Nba Chicago Bulls Cup", 6.0 },
                    { 4, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-la-lakers (1).jpg", "Nba Los Angeles Lakers Cup", 6.0 },
                    { 5, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-la-lakers.jpg", "Nba Los Angeles Lakers Cup 2", 6.0 },
                    { 6, 19, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-logo.jpg", "Nba Logo Cup", 5.0 },
                    { 7, 10, "Quickly inflate your favorite ball with the Jordan Essentials Ball Pump. Its compact design makes it easy to carry, and ideal for supplementing the ball air.", "\\images\\products\\Jordan Essential Ball Pump Intl.jpg", "Jordan Essential Ball Pump Intl", 19.989999999999998 },
                    { 8, 10, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Nike Essential Ball Pump Intl.jpg", "Nike Essential Ball Pump Intl", 16.989999999999998 },
                    { 9, 10, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Nike Hyperspeed Ball Pump Intl Swoosh.jpg", "Nike Hyperspeed Ball Pump Intl Swoosh", 24.5 },
                    { 10, 10, "The Spalding dual action power pump comes with an attached extension hose. The 12” pump fits all types of valves (includes two different sized needles) and pumps air by pushing and pulling action.", "\\images\\products\\Spalding 12' Dual Action Power Pump.jpg", "Spalding 12' Dual Action Power Pump", 18.0 },
                    { 11, 10, "Dual action Aluminium pump with durable extension hose.", "\\images\\products\\Wilson Nba Authentic Aluminum Pump.jpg", "Wilson Nba Authentic Aluminum Pump", 21.899999999999999 },
                    { 12, 10, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 13, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Brooklyn Nets Stickers.jpg", "NBA Brooklyn Nets Stickers", 0.90000000000000002 },
                    { 14, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Chicago Bulls Stickers.png", "NBA Chicago Bulls Stickers", 0.90000000000000002 },
                    { 15, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Dallas Mavericks Stickers.png", "NBA Dallas Mavericks Stickers", 0.90000000000000002 },
                    { 16, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Golden State Stickers.jpg", "NBA Golden State Stickers", 0.90000000000000002 },
                    { 17, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Milwauke Bucks Stickers.png", "NBA Milwauke Bucks Stickers", 0.90000000000000002 },
                    { 18, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Stickers.jpg", "NBA Stickers", 0.90000000000000002 },
                    { 19, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Phoenix Suns Stickers.jpg", "NBA Phoenix Suns Stickers", 0.90000000000000002 },
                    { 20, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Pvc Stickers Nba Boston Celtics.jpg", "Nba Boston Celtics Stickers", 0.90000000000000002 },
                    { 21, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Pvc Stickers Ny Knics.jpg", "NBA New York Knicks Stickers", 0.90000000000000002 },
                    { 22, 24, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Los Angeles Lakers Stickers.jpg", "NBA Los Angeles Lakers Stickers", 0.90000000000000002 },
                    { 23, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Jordan Unisex Shooter Sleeves.jpg", "Jordan Unisex Shooter Sleeves", 61.990000000000002 },
                    { 24, 11, "If you're wondering why you need these COMPRESSPORT Armforce Ultralight Sleeves if you're doing your favorite sports when the weather gets colder, the answer is to provide you with the thermoregulation you need when exposed to cold air. Featuring gentle compression properties, they precisely target core muscles for stimulated blood flow and support. For running, cycling or hiking these sleeves will hug your hands while protecting and keeping them warm.", "\\images\\products\\COMPRESSPORT Armforce Ultralight.jpg", "COMPRESSPORT Armforce Ultralight", 28.0 },
                    { 25, 11, "Pro Elite Sleeves 2.0, are made with Dri-FIT technology removing sweat for a dry and comfortable feel. Their preformed construction ensures enhanced mobility, while flat seams eliminate friction and irritation.", "\\images\\products\\Nike Pro Elite SLeeves 2.0.jpg", "Nike Pro Elite SLeeves 2.0 ", 29.899999999999999 },
                    { 26, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg", "Nike Pro Elbow Sleeve 3.0", 22.949999999999999 },
                    { 27, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Nike Pro Ankle Sleeve 3.0.jpg", "Nike Pro Ankle Sleeve 3.0", 21.989999999999998 },
                    { 28, 11, "Utilised by the best in the game to improve performance, these form fitting sleeves provide superior support and protection. The compression fit allows a wide range of motion and muscle support. The Dri-FIT fabric wicks moisture away for comfort.Sold in pairs", "\\images\\products\\Jordan Unisex Shooter Sleeves.jpg", "Nike NBA 2.0 Basketball Shooter Sleeve", 34.5 },
                    { 29, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Mcdavid Hex Shooter Arm SLeeve.jpg", "Mcdavid Hex Shooter Arm SLeeve", 30.0 },
                    { 30, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Mcdavid Power Shooter Arm SLeeve.jpg", "Mcdavid Power Shooter Arm SLeeve", 27.989999999999998 },
                    { 31, 11, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\MCDAVID Elite Compression Arm Sleeve.jpg", "MCDAVID Elite Compression Arm Sleeve", 24.989999999999998 },
                    { 32, 12, "Nike Playground 8P 2.0 G Antetokounmpo Deflated", "\\images\\products\\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg", "Nike Playground 8P 2.0 G Antetokounmpo Deflated Basketball", 33.5 },
                    { 33, 12, "The SKLZ Control basketball is the perfect training ball to help athletes improve their dribbling skills. It is made of high quality synthetic leather for indoor and outdoor training.", "\\images\\products\\SKLZ Lightweight Control Basketball Ball.jpg", "SKLZ Lightweight Control Basketball ", 39.899999999999999 },
                    { 34, 12, "Nike All Court 8P Z Williamson Deflated", "\\images\\products\\Nike All Court 8P Z Williamson Deflated.jpg", "Nike All Court 8P Z Williamson Deflated Basketball", 51.5 },
                    { 35, 12, "Nike Basketball 8P Energy Deflated", "\\images\\products\\Nike Basketball 8P Energy Deflated.jpg", "Nike Basketball 8P Energy Deflated ", 57.149999999999999 },
                    { 36, 12, "Nike Elite Tournament 8P Deflated", "\\images\\products\\Nike Elite Tournament 8P Deflated.jpg", "Nike Elite Tournament 8P Deflated Basketball", 68.900000000000006 },
                    { 37, 12, "Wilson Nba Official Game Ball Bskt Retail", "\\images\\products\\Wilson Nba Official Game Ball Bskt Retail.jpg", "Wilson Nba Official Game Basketball Retail", 259.0 },
                    { 38, 12, "Nike Championship 8P Deflated", "\\images\\products\\Nike Championship 8P Deflated.jpg", "Nike Championship 8P Deflated Basketball", 104.0 },
                    { 39, 12, "Nike Basketball 8P Prm Energy Deflated", "\\images\\products\\Nike Basketball 8P Prm Energy Deflated.jpg", "Nike Basketball 8P Prm Energy Deflated", 57.509999999999998 },
                    { 40, 12, "Nike Skills", "\\images\\products\\Nike Skills.jpg", "Nike Skills Basketball", 13.5 },
                    { 41, 12, "Nike Everyday All Court 8P Graphic Deflated", "\\images\\products\\Nike Everyday All Court 8P Graphic Deflated.jpg", "Nike Everyday All Court 8P Graphic Deflated Basketball", 39.899999999999999 },
                    { 42, 12, "Nike Ultimate 2.0 8P Graphic Deflated", "\\images\\products\\Nike Ultimate 2.0 8P Graphic Deflated.jpg", "Nike Ultimate 2.0 8P Graphic Deflated Basketball", 44.899999999999999 },
                    { 43, 13, "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.", "\\images\\products\\Wilson NBA Milwaukee Bucks Mini Hoop.jpg", "Wilson NBA Milwaukee Bucks Mini Hoop", 27.399999999999999 },
                    { 44, 13, "Basketball Dashboard set", "\\images\\products\\Amila Basketball Dashboard 16Mm.jpg", "Amila Basketball Dashboard 16Mm", 115.90000000000001 },
                    { 45, 13, "Amila Basketball With Hoop Net 2.27-3.05M", "\\images\\products\\Amila Basketball With Hoop Net 2.27-3.05M.jpg", "Amila Basketball With Hoop Net 2.27-3.05M", 279.89999999999998 },
                    { 46, 13, "Amila handheld basket with adjustable height for family play. Ideal for indoor and outdoor use. Dashboard made of durable polycarbonate material with steel edging. The vinyl base is filled with water or sand for guaranteed stability in play.", "\\images\\products\\Amila Basket Semi-Professional, Thickness 3.0Mm.jpg", "Amila Basket Semi-Professional, Thickness 3.0Mm.jpg", 374.89999999999998 },
                    { 47, 13, "SKLZ Pro Mini Hoop System", "\\images\\products\\SKLZ Pro Mini Hoop System.jpg", "SKLZ Pro Mini Hoop System", 219.94999999999999 },
                    { 48, 13, "Portable basketball from the Highlight series of Spalding. With acrylic board width 42 '' and variable height from 2.28 to 3.05 meters so that both the youngest and the oldest basketball fans can enjoy the game!", "\\images\\products\\Spalding 2015 Highlight Portable 42'' Acrylic.jpg", "Spalding 2015 Highlight Portable 42'' Acrylic", 435.60000000000002 },
                    { 49, 13, "Amila Backboard with three-colour net.", "\\images\\products\\Amila Backboard 122 x 85 cm 49197.jpg", "Amila Backboard 122 x 85 cm 49197", 219.90000000000001 },
                    { 50, 13, "Amila Basketball Hoop with Springs & Net.", "\\images\\products\\Amila Basketball Hoop with Springs & Net.jpg", "Amila Basketball Hoop with Springs & Net", 67.900000000000006 },
                    { 51, 13, "Basket wreath with steel tube and spring for pressure absorption from ball hitting and hanging by players. Its diameter is 45cm and includes net in the package. Suitable for every dashboard and basketball to play on the court, garden or cottage.", "\\images\\products\\Amila Basketball Hoop.jpg", "Amila Basketball Hoop", 64.900000000000006 },
                    { 52, 14, "Red, white and blue throwback design.Fits all standard size rims.Suitable for indoor and outdoor courts", "\\images\\products\\Wilson Nba Drv Recreational Basketball Net.jpg", "Wilson Nba Drv Recreational Basketball Net", 10.9 },
                    { 53, 14, "Amila Basketball Net.One piece per package.", "\\images\\products\\Amila Basketball Net.jpg", "Amila Basketball Net", 6.9000000000000004 },
                    { 54, 14, "Red, white and blue throwback design.Fits all standard size rims.Suitable for indoor and outdoor courts", "\\images\\products\\Spalding All Weather Basketball Net.jpg", "Spalding All Weather Basketball Net", 10.9 },
                    { 55, 14, "This metal wreath by Amila weighs 590 g and is ideal for outdoor use.", "\\images\\products\\Amila Basketball Net 45cm.jpg", "Amila Basketball Net 45cm", 12.9 },
                    { 56, 14, "Professional and durable basketball net with 12 hooks, ideal for a unique hooping game.", "\\images\\products\\Amila Basketball Net 1 piece 0.4cm.jpg", "Amila Basketball Net 1 piece 0.4cm", 9.9000000000000004 },
                    { 57, 15, "New Era design & Lakers.Regular fit.100% acryllic", "\\images\\products\\ΝBA Los Angeles Lakers Men's Beanie.jpg", "ΝBA Los Angeles Lakers Men's Beanie", 30.0 },
                    { 58, 15, "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.", "\\images\\products\\ΝBA Chicago Bulls Men's Beanie.jpg", "ΝBA Chicago Bulls Men's Beanie", 33.0 },
                    { 59, 15, "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.", "\\images\\products\\Nba21 City Off Knit Milbuc Men's Beanie.jpg", "Nba21 City Off Knit Milbuc Men's Beanie", 33.0 },
                    { 60, 15, "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.", "\\images\\products\\Nba21 City Off Knit Loslak Men's Beanie.jpg", "Nba21 City Off Knit Loslak Men's Beanie", 33.0 },
                    { 61, 15, "Stay warm wherever you are with your favorite team and take off your winter outfit with the men's cap from NEW ERA. Enjoy your everyday life to the maximum with an absolute street outfit and without the cold getting in the way.", "\\images\\products\\Nba21 City Alt Knit Miami Heat Men's Beanie.jpg", "Nba21 City Alt Knit Miami Heat Men's Beanie", 33.0 },
                    { 62, 15, "Low temperatures limit the range of your daily activities. But this is not the case for Jordan. The heart of her new collection is the comfort and the cozy vibes that we all love so much and want every moment of our daily lives. Indulge fearlessly in every activity without being limited by the cold!", "\\images\\products\\Jordan Utility Metal Unisex Beanie.jpg", "Jordan Utility Metal Unisex Beanie", 35.899999999999999 },
                    { 63, 15, "Low temperatures limit the range of your daily activities. But this is not the case for Jordan. The heart of her new collection is the comfort and the cozy vibes that we all love so much and want every moment of our daily lives. Indulge fearlessly in every activity without being limited by the cold!", "\\images\\products\\Jordan Utility Metal Unisex Beanie Red.jpg", "Jordan Utility Metal Unisex Beanie Red", 35.899999999999999 },
                    { 64, 16, "Complete each athleisure outfit with a cap! This cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style.", "\\images\\products\\Jordan Clc99 Air Men's Tracker Cap.jpg", "Jordan Clc99 Air Men's Tracker Cap", 34.600000000000001 },
                    { 65, 16, "This Jordan Pro Jumpman Snapback hat takes your style to the next level and features an embroidered Jumpman design on the front. Top quality fabric and design with back pleats ensure a classic look.", "\\images\\products\\Jordan Pro Jumpman Snapback Unisex Hat.jpg", "Jordan Pro Jumpman Snapback Unisex Hat", 24.899999999999999 },
                    { 66, 16, "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.", "\\images\\products\\Jordan Pro Jumpman Classics Cap.jpg", "Jordan Pro Jumpman Classics Cap", 26.989999999999998 },
                    { 67, 16, "NEW ERA NBA Finals 950 Denver Nuggets", "\\images\\products\\NBA Finals 950 Dennug.jpg", "NBA Finals 950 Denver Nuggets", 40.0 },
                    { 68, 16, "NEW ERA NBA Finals 950 Miami Heat", "\\images\\products\\NBA Finals 950 Miahea.jpg", "NBA Finals 950 Miami Heat", 40.0 },
                    { 69, 16, "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.", "\\images\\products\\Jordan Pro Jumpman Classics Cap Black.jpg", "Jordan Pro Jumpman Classics Cap Black", 26.989999999999998 },
                    { 70, 16, "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.", "\\images\\products\\Jordan Pro Jumpman Classics Cap Mint.jpg", "Jordan Pro Jumpman Classics Cap Mint", 26.989999999999998 },
                    { 71, 16, "Complete each athleisure outfit with a cap! The new Jordan Pro Jumpman Classics Cap is made from lightweight fabric, features a sightly curved brim and of course the iconic Jumpman style. Its premium fabric and snapback design give you a classic look.", "\\images\\products\\Jordan Pro Jumpman Classics Cap Orange.jpg", "Jordan Pro Jumpman Classics Cap Orange", 26.989999999999998 },
                    { 72, 16, "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.", "\\images\\products\\Jordan Jumpman Washed Bucket Hat.jpg", "Jordan Jumpman Washed Bucket Hat", 34.990000000000002 },
                    { 73, 16, "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.", "\\images\\products\\Jordan Jumpman Washed Bucket Hat White.jpg", "Jordan Jumpman Washed Bucket Hat White", 34.990000000000002 },
                    { 74, 16, "The Jordan Jumpman Bucket Hat is made from lightweight woven twill that's been washed for a vintage look to top off your style. Combine it with your favorite outfit & skyrocket your style.", "\\images\\products\\Jordan Jumpman Washed Bucket Hat Red.jpg", "Jordan Jumpman Washed Bucket Hat Red", 34.990000000000002 },
                    { 75, 17, "Nike Pro Wrist And Thumb Wrap 3.1", "\\images\\products\\Nike Pro Wrist And Thumb Wrap.jpg", "Nike Pro Wrist And Thumb Wrap 3.1", 21.989999999999998 },
                    { 76, 17, "The Nike NBA Basketball Headband features sweat-wicking fabric to help keep your head dry and comfortable for optimal performance on the court.Dri-FIT Technology helps keep you dry and comfortable.Breathable knit provides optimal airflow", "\\images\\products\\Nike NBA Unisex Headband White.jpg", "Nike NBA Unisex Headband White", 21.899999999999999 },
                    { 77, 17, "The Nike NBA Basketball Headband features sweat-wicking fabric to help keep your head dry and comfortable for optimal performance on the court.Dri-FIT Technology helps keep you dry and comfortable.Breathable knit provides optimal airflow", "\\images\\products\\Nike NBA Unisex Headband Black.jpg", "Nike NBA Unisex Headband Black", 21.899999999999999 },
                    { 78, 17, "The Jordan Jumpman Headband helps keep your sweat away while playing the game. Made of soft materials, this headband will keep you dry.Lasting Comfort. Secure Fit.\r\n", "\\images\\products\\Jordan Jumpman Unisex Headband Black.jpg", "Jordan Jumpman Unisex Headband Black", 17.5 },
                    { 79, 17, "The Jordan Jumpman Headband helps keep your sweat away while playing the game. Made of soft materials, this headband will keep you dry.Lasting Comfort. Secure Fit.", "\\images\\products\\Jordan Jumpman Unisex Headband.jpg", "Jordan Jumpman Unisex Headband", 17.5 },
                    { 80, 17, "This Jordan Jumpman Wristbands will keep sweat away from your skin! It’s made from a soft fabric that absorbs sweat and reduces distractions to get absolute concentration in the game.", "\\images\\products\\Jordan Jumpman Wristbands.jpg", "Jordan Jumpman Wristbands", 18.899999999999999 },
                    { 81, 17, "This Jordan Jumpman Wristbands will keep sweat away from your skin! It’s made from a soft fabric that absorbs sweat and reduces distractions to get absolute concentration in the game.", "\\images\\products\\Jordan Jumpman Wristbands Black.jpg", "Jordan Jumpman Wristbands Black", 18.899999999999999 },
                    { 82, 17, "Flaunt your allegiance to the NBA® when you sport the Nike NBA® On-Court Wristbands. The breathable, moisture-wicking bands are made of comfortable nylon fabric to keep you cool and dry during the most intense games.", "\\images\\products\\Nike Wristbands Nba.jpg", "Nike Wristbands Nba", 24.899999999999999 },
                    { 83, 17, "Flaunt your allegiance to the NBA® when you sport the Nike NBA® On-Court Wristbands. The breathable, moisture-wicking bands are made of comfortable nylon fabric to keep you cool and dry during the most intense games.", "\\images\\products\\Nike Wristbands Nba Black.jpg", "Nike Wristbands Nba Black", 24.899999999999999 },
                    { 84, 18, "Show off your pride in your team wherever you go! This is the ideal way to keep warm and declare your allegiance when you're off the court or warming up.", "\\images\\products\\Jordan NBA Charlotte Hornets Club Men's Hoodie.jpg", "Jordan NBA Charlotte Hornets Club Men's Hoodie", 64.0 },
                    { 85, 18, "Show off your pride in your team wherever you go! This is the ideal way to keep warm and declare your allegiance when you're off the court or warming up.", "\\images\\products\\Jordan NBA Chicago Bulls Courtside Statement Edition Men's Hoodie.jpg", "Jordan NBA Chicago Bulls Courtside Statement Edition Men's Hoodie", 64.0 },
                    { 86, 18, "Layer up in this soft and roomy Milwaukee Bucks fleece hoodie to shrug off the chill in cooler temps. Displaying proud graphics in squad colors, it pays tribute to your favorite team.", "\\images\\products\\Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie.jpg", "Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie", 65.0 },
                    { 87, 18, "Designed for players to wear at practice, the Brooklyn Nets Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.", "\\images\\products\\Nike Dri-FIT NBA Brooklyn Nets Spotlight Men's Hoodie.jpg", "Nike Dri-FIT NBA Brooklyn Nets Spotlight Men's Hoodie", 65.0 },
                    { 88, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Boston Celtics Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBA Boston Celtics Men's Hoodie.jpg", "Nike NBA Boston Celtics Men's Hoodie", 59.0 },
                    { 89, 18, "Designed for players to wear at practice, the Los Angeles Lakers Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.", "\\images\\products\\Nike NBA Dri-FIT Los Angeles Lakers Spotlight Men's Hoodie.jpg", "Nike NBA Dri-FIT Los Angeles Lakers Spotlight Men's Hoodie", 65.0 },
                    { 90, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Golden State Wariors Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBA Golden State Wariors Club Men's Hoodie.jpg", "Nike NBA Golden State Wariors Club Men's Hoodie", 59.0 },
                    { 91, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Los Angeles Lakers Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBA Los Angeles Lakers Club Men's Hoodie.jpg", "Nike NBA Los Angeles Lakers Club Men's Hoodie", 59.0 },
                    { 92, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Logo Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike Team 31 Club Fleece Mens Hoodie.png", "Nike Team 31 Club Fleece Mens Hoodie", 50.0 },
                    { 93, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Brooklyn Nets Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBA Brooklyn Nets Club Men's Hoodie.png", "Nike NBA Brooklyn Nets Club Men's Hoodie", 59.0 },
                    { 94, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Chicago Bulls Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBAChicago Bulls Club Men's Hoodie.jpg", "Nike NBA Chicago Bulls Club Men's Hoodie", 59.0 },
                    { 95, 18, "Designed for players to wear at practice, the Golden State Warriors Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.", "\\images\\products\\Nike Dri FIT NBA Golden State Warriors Men's Hoodie.png", "Nike Dri FIT NBA Golden State Warriors Men's Hoodie", 65.0 },
                    { 96, 18, "Designed for players to wear at practice, the Milwaukee Bucks Hoodie has you covered in soft, sweat-wicking technology that helps you stay dry. Its relaxed fit helps keep you comfortable on or off the court.", "\\images\\products\\Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie.png", "Nike Dri FIT NBA Milwaukee Bucks Men's Hoodie", 65.0 },
                    { 97, 18, "The cold weather can in some cases quench your thirst for exercise. Not anymore! With this warm and comfortable Nike NBA Milwaukee Bucks Men's Hoodie your favorite American league team accompanies you even on the coldest days of the year. With spacious side pockets and an additional one in the front that closes with a zipper, you can have your favorite items with you while you exercise. Rib cuffs on the sleeves allow body temperature to remain constant", "\\images\\products\\Nike NBA Milwaukee Bucks Club Men's Hoodie.png", "Nike NBA Milwaukee Bucks Club Men's Hoodie", 59.0 },
                    { 100, 21, "Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey", "\\images\\products\\Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey.png", "Allen Iverson Philadelphia 76ers 2000-01 Mitchell & Ness NBA Jersey", 105.0 },
                    { 101, 21, "Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey", "\\images\\products\\Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey.jpg", "Anfernee Penny Hardaway Orlando Magic Mitchell & Ness Jersey", 105.0 },
                    { 102, 21, "Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness", "\\images\\products\\Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness.png", "Chicago Bulls Michael Jordan 1997 Road Authentic Jersey By Mitchell & Ness", 105.0 },
                    { 103, 21, "Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey", "\\images\\products\\Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey.png", "Clyde Drexler Portland Trail Blazers 1991-92 Mitchell & Ness NBA Jersey", 105.0 },
                    { 104, 21, "Dennis Rodman Chicago Bulls Mitchell & Ness NBA Jersey", "\\images\\products\\Dennis Rodman Chicago Bulls Mitchell & Ness NBA  Jersey.jpg", "Dennis Rodman Chicago Bulls Mitchell & Ness NBA Jersey", 105.0 },
                    { 105, 21, "Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey", "\\images\\products\\Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey.png", "Detlef Schrempf Seattle SuperSonics 1994-95 Mitchell & Ness NBA Jersey", 105.0 },
                    { 106, 21, "Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey", "\\images\\products\\Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey.png", "Dirk Nowitzki Dallas Mavericks 1998-99 Mitchell & Ness NBA Jersey", 105.0 },
                    { 107, 21, "Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey", "\\images\\products\\Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey.png", "Dominique Wilkins Atlanta Hawks 1986-87 Mitchell & Ness NBA Jersey", 105.0 },
                    { 108, 21, "Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey", "\\images\\products\\Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey.png", "Gary Payton Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey", 105.0 },
                    { 109, 21, "Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey", "\\images\\products\\Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey.png", "Grant Hill Detroit Pistons 1999-00 Mitchell & Ness NBA Jersey", 105.0 },
                    { 110, 21, "Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey", "\\images\\products\\Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey.png", "Isiah Thomas Detroit Pistons 1988-89 Mitchell & Ness NBA Jersey", 105.0 },
                    { 111, 21, "Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA Jersey", "\\images\\products\\Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA  Jersey.png", "Kareem Abdul Jabbar Los Angeles Lakers 1984-85 Mitchell & Ness NBA Jersey", 105.0 },
                    { 112, 21, "Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA Jersey", "\\images\\products\\Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA  Jersey.png", "Karl Malone Utah Jazz 1996-97  Mitchell & Ness NBA Jersey", 105.0 },
                    { 113, 21, "Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA  Jersey", "\\images\\products\\Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA  Jersey.png", "Magic Johnson Los Angeles Lakers 1984 Mitchell & Ness NBA Jersey", 105.0 },
                    { 114, 21, "Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey", "\\images\\products\\Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey.png", "Patrick Ewing New York Knicks 1991-92 Mitchell & Ness NBA Jersey", 105.0 },
                    { 115, 21, "Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey", "\\images\\products\\Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey.png", "Shaquille ONeal Los Angeles Lakers 1999-00 Mitchell & Ness Jersey", 105.0 },
                    { 116, 21, "Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey", "\\images\\products\\Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey.png", "Shawn Kemp Seattle SuperSonics 1995-96 Mitchell & Ness NBA Jersey", 105.0 },
                    { 117, 21, "Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey", "\\images\\products\\Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey.png", "Steve Nash Phoenix Suns Mitchell & Ness NBA Jersey", 105.0 },
                    { 118, 21, "Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey", "\\images\\products\\Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey.jpg", "Vince Carter Toronto Raptors Mitchell & Ness NBA Jersey", 105.0 },
                    { 119, 21, "Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey", "\\images\\products\\Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey.png", "Vlade Divac Sacramento Kings 2000-01 Mitchell & Ness NBA Jersey", 105.0 },
                    { 120, 21, "Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey", "\\images\\products\\Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey.png", "Yao Ming Houston Rockets 2002-03 Mitchell & Ness NBA Jersey", 105.0 },
                    { 126, 22, "From the first time he stepped on the court, Donovan Mitchell changed the rules of the game and continues to do so to this day. These D.O.N. Issue 5 adidas Basketball signature shoes show Spida's personal style, but also his social activity. These basketball sneakers help you dominate the game thanks to the lightweight Lightstrike midsole and unique rubber outsole with an upgraded traction pattern.", "\\images\\products\\adidas Performance D.O.N. Issue 5  Men's Basketball Shoes.png", "adidas Performance D.O.N. Issue 5  Men's Basketball Shoes", 86.0 },
                    { 127, 22, "It's been 10 years since the LeBron 9 made its debut and helped propel King James to a championship. Now, the model is back, ready for casual games and hitting the streets afterwards. This new colourway pairs theme-park pink with teddy-bear brown on super-soft, fluffy fabric. Gradient accents recall summer nights at the theme park. Lace up and take a step into LeBron's world.\r\n\r\n.", "\\images\\products\\Nike Lebron IX -King of LA- Men's Basketball Shoes.png", "Nike Lebron IX -King of LA- Men's Basketball Shoes", 127.0 },
                    { 128, 22, "Strike on court wearing the Curry 3Z5 by Under Armour. Thes basketball boots are made from lightweight breathable mesh upper featuring micro G foam midsole turning landing into explosive takeoffs.\r\n", "\\images\\products\\Under Armour Curry 3Z5 Men's Basketball Shoes.png", "Under Armour Curry 3Z5 Men's Basketball Shoes", 18.600000000000001 },
                    { 131, 22, "These basketball shoes provide exceptional durability while you won't run away from friction. Signed by Damian Lillard and adidas, they give you confidence whether you're shooting baskets or in the gym. They feature a Bounce Pro midsole that combines increased stability with lightweight, flexible cushioning as well as an inner sock construction and TPU propulsion plate. They are completed with the brand's design.\r\n", "\\images\\products\\adidas Performance Dame 8 Extply Men's Basketball Shoes.png", "adidas Performance Dame 8 Extply Men's Basketball Shoes", 130.0 },
                    { 132, 22, "This basketball shoe is inspired by the environment and life of John. Giannis Antetokounmpo has explosive power on the court and needs a shoe that can fully showcase his exceptional ability. The Zoom Freak 5 adopts a fast design to help it launch with amazing speed. At the same time, it is equipped with an absorption configuration to bring a bounce effect to the game. Do your thing and rush past your opponents or pull off key defensive moves like Giannis. Whatever you do, the durable rubber outsole gives you strong traction to get it done.\r\n", "\\images\\products\\Nike Freak 5 ,Made in Sepolia,Men's Basketball Shoes.jpg", "Nike Freak 5 ,Made in Sepolia,Men's Basketball Shoes", 124.98999999999999 },
                    { 134, 22, "The Freak 5 is a basketball shoe that can tame the impressive potential of the Greek Freak. Built with technology that offers speed as well as elastic cushioning, the signature shoe of Giannis offers it all.", "\\images\\products\\Nike Zoom Freak 5 Men's Basketball Shoes.jpg", "Nike Zoom Freak 5 Men's Basketball Shoes", 135.0 },
                    { 135, 22, "The KD Trey 5 X has a lightweight upper and soft support system to give you KD's airy movement while you wait for the perfect moment to get to the basket. The stable midfoot strap is suitable for non-stop scoring and helping to defend, so you can enjoy a stable feel and win all the time.\r\n", "\\images\\products\\Nike KD Trey 5 X Men's Basketball Boots.png", "Nike KD Trey 5 X Men's Basketball Boots", 95.599999999999994 },
                    { 136, 22, "Designed for a quick, crafty game, this shoe enables players who use their speed and multi-directional ability to stay in control while taking advantage of the separation they create.", "\\images\\products\\Nike Kyrie Low 5 Men's Basketball Shoes.png", "Nike Kyrie Low 5 Men's Basketball Shoes", 74.989999999999995 },
                    { 139, 23, "Jordan Ultimate Flight 2.0 Crew", "\\images\\products\\Jordan Ultimate Flight 2.0 Crew.jpg", "Jordan Ultimate Flight 2.0 Crew Socks", 17.989999999999998 },
                    { 140, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-nyk-ce24.jpg", "Stance New York Knicks socks", 19.989999999999998 },
                    { 141, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-mil-ce24.jpg", "Stance Milwaukee Bucks socks", 19.989999999999998 },
                    { 142, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-mem-ce24.jpg", "Stance Memphies Grizzlies socks", 19.989999999999998 },
                    { 143, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-lal-ce24.jpg", "Stance Los Angeles Lakers socks", 19.989999999999998 },
                    { 144, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-chi-ce24.jpg", "Stance Chicago Bulls socks", 19.989999999999998 },
                    { 145, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-dal-ce24.jpg", "Stance Dallas Mavericks socks", 19.989999999999998 },
                    { 146, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-den-ce24.jpg", "Stance Denver Nuggets socks", 19.989999999999998 },
                    { 147, 23, "Complete your street look with your favourite NBA team 2024 socks. The crew socks, carry an impressive design and are here to fill your day with comfort.", "\\images\\products\\stance-gsw-ce24.jpg", "Stance Golden State Warriors socks", 19.989999999999998 },
                    { 148, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Atlanta Hawks Official Jersey.png", "Atlanta Hawks Official Jersey", 96.900000000000006 },
                    { 149, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Boston Celtics Official Jersey.png", "Boston Celtics Official Jersey", 96.900000000000006 },
                    { 150, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Brooklyn Nets Official Jersey.png", "Brooklyn Nets Official Jersey", 96.900000000000006 },
                    { 151, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Charlotte Hornets Official Jersey.png", "Charlotte Hornets Official Jersey", 96.900000000000006 },
                    { 152, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Chicago Bulls Official Jersey.png", "Chicago Bulls Official Jersey", 96.900000000000006 },
                    { 153, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Cleveland Cavaliers Official Jersey.png", "Cleveland Cavaliers Official Jersey", 96.900000000000006 },
                    { 154, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Dallas Mavericks Official Jersey.png", "Dallas Mavericks Official Jersey", 96.900000000000006 },
                    { 155, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Denver Nuggets Official Jersey.png", "Denver Nuggets Official Jersey", 96.900000000000006 },
                    { 156, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Detroit Pistons Official Jersey.png", "Detroit Pistons Official Jersey", 96.900000000000006 },
                    { 157, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Golden State Warriors Official Jersey.png", "Golden State Warriors Official Jersey", 96.900000000000006 },
                    { 158, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Houston Rockets Official Jersey.png", "Houston Rockets Official Jersey", 96.900000000000006 },
                    { 159, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Indiana Pacers Official Jersey.png", "Indiana Pacers Official Jersey", 96.900000000000006 },
                    { 160, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\LA Clippers Official Jersey.png", "LA Clippers Official Jersey", 96.900000000000006 },
                    { 161, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Los Angeles Lakers Official Jersey.png", "Los Angeles Lakers Official Jersey", 96.900000000000006 },
                    { 162, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Memphis Grizzlies Official Jersey.png", "Memphis Grizzlies Official Jersey", 96.900000000000006 },
                    { 163, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Miami Heat Official Jersey.png", "Miami Heat Official Jersey", 96.900000000000006 },
                    { 164, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Milwaukee Bucks Official Jersey.png", "Milwaukee Bucks Official Jersey", 96.900000000000006 },
                    { 165, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Minnesota Timberwolves Official Jersey.png", "Minnesota Timberwolves Official Jersey", 96.900000000000006 },
                    { 166, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\New Orleans Pelicans Official Jersey.png", "New Orleans Pelicans Official Jersey", 96.900000000000006 },
                    { 167, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\New York Knicks Official Jersey.png", "New York Knicks Official Jersey", 96.900000000000006 },
                    { 168, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Oklahoma City Thunder Official Jersey.png", "Oklahoma City Thunder Official Jersey", 96.900000000000006 },
                    { 169, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Orlando Magic Official Jersey.png", "Orlando Magic Official Jersey", 96.900000000000006 },
                    { 170, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Philadelphia 76ers Official Jersey.png", "Philadelphia 76ers Official Jersey", 96.900000000000006 },
                    { 171, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Phoenix Suns Official Jersey.png", "Phoenix Suns Official Jersey", 96.900000000000006 },
                    { 172, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Portland Trail Blazers Official Jersey.png", "Portland Trail Blazers Official Jersey", 96.900000000000006 },
                    { 173, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Sacramento Kings Official Jersey.png", "Sacramento Kings Official Jersey", 96.900000000000006 },
                    { 174, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\San Antonio Spurs Official Jersey.png", "San Antonio Spurs Official Jersey", 96.900000000000006 },
                    { 175, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit.", "\\images\\products\\Toronto Raptors Official Jersey.png", "Toronto Raptors Official Jersey", 96.900000000000006 },
                    { 176, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit", "\\images\\products\\Utah Jazz Official Jersey.png", "Utah Jazz Official Jersey", 96.900000000000006 },
                    { 177, 20, "When you want that step closer to a genuine NBA jersey you can't go wrong with this. Constructed with superb care and quality materials this is an excellent facsimile of the players' own alternate kit", "\\images\\products\\Washington Wizards Official Jersey.png", "Washington Wizards Official Jersey", 96.900000000000006 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
