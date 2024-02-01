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
                    Firstname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                columns: new[] { "CategoryId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Air Pumps" },
                    { 2, 2, "Arm Sleeves" },
                    { 3, 3, "Balls" },
                    { 4, 4, "Basket" },
                    { 5, 5, "Basketball Nets" },
                    { 6, 6, "Beanies" },
                    { 7, 7, "Hats" },
                    { 8, 8, "Headbands - Wristbands" },
                    { 9, 9, "Hoodies" },
                    { 10, 10, "Mugs & Cups" },
                    { 11, 11, "ΝΒΑ Jerseys" },
                    { 12, 12, "ΝΒΑ Retro Jerseys" },
                    { 13, 13, "Shoes" },
                    { 14, 14, "Socks" },
                    { 15, 15, "Stickers" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-boston-celtics.jpg", "Nba Boston Celtics Cup", 6.0 },
                    { 2, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-bucks.jpg", "Nba Milwaukee Bucks Cup", 6.0 },
                    { 3, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-bulls.jpg", "Nba Chicago Bulls Cup", 6.0 },
                    { 4, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-la-lakers (1).jpg", "Nba Los Angeles Lakers Cup", 6.0 },
                    { 5, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-la-lakers.jpg", "Nba Los Angeles Lakers Cup 2", 6.0 },
                    { 6, 10, "Ceramic mugs and cups with your favorite NBA team", "\\images\\products\\back-me-up-cup-nba-logo.jpg", "Nba Logo Cup", 5.0 },
                    { 7, 1, "Quickly inflate your favorite ball with the Jordan Essentials Ball Pump. Its compact design makes it easy to carry, and ideal for supplementing the ball air.", "\\images\\products\\Jordan Essential Ball Pump Intl.jpg", "Jordan Essential Ball Pump Intl", 19.989999999999998 },
                    { 8, 1, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Nike Essential Ball Pump Intl.jpg", "Nike Essential Ball Pump Intl", 16.989999999999998 },
                    { 9, 1, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Nike Hyperspeed Ball Pump Intl Swoosh.jpg", "Nike Hyperspeed Ball Pump Intl Swoosh", 24.5 },
                    { 10, 1, "The Spalding dual action power pump comes with an attached extension hose. The 12” pump fits all types of valves (includes two different sized needles) and pumps air by pushing and pulling action.", "\\images\\products\\Spalding 12' Dual Action Power Pump.jpg", "Spalding 12' Dual Action Power Pump", 18.0 },
                    { 11, 1, "Dual action Aluminium pump with durable extension hose.", "\\images\\products\\Wilson Nba Authentic Aluminum Pump.jpg", "Wilson Nba Authentic Aluminum Pump", 21.899999999999999 },
                    { 12, 1, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 13, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Brooklyn Nets Stickers.jpg", "NBA Brooklyn Nets Stickers", 0.90000000000000002 },
                    { 14, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Chicago Bulls Stickers.png", "NBA Chicago Bulls Stickers", 0.90000000000000002 },
                    { 15, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Dallas Mavericks Stickers.png", "NBA Dallas Mavericks Stickers", 0.90000000000000002 },
                    { 16, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Golden State Stickers.jpg", "NBA Golden State Stickers", 0.90000000000000002 },
                    { 17, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Milwauke Bucks Stickers.png", "NBA Milwauke Bucks Stickers", 0.90000000000000002 },
                    { 18, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Stickers.jpg", "NBA Stickers", 0.90000000000000002 },
                    { 19, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Phoenix Suns Stickers.jpg", "NBA Phoenix Suns Stickers", 0.90000000000000002 },
                    { 20, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Pvc Stickers Nba Boston Celtics.jpg", "Nba Boston Celtics Stickers", 0.90000000000000002 },
                    { 21, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up Pvc Stickers Ny Knics.jpg", "NBA New York Knicks Stickers", 0.90000000000000002 },
                    { 22, 15, "A pack of two stickers featuring your favourite NBA team!", "\\images\\products\\Back Me Up NBA Los Angeles Lakers Stickers.jpg", "NBA Los Angeles Lakers Stickers", 0.90000000000000002 },
                    { 23, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Jordan Unisex Shooter Sleeves.jpg", "Jordan Unisex Shooter Sleeves", 61.990000000000002 },
                    { 24, 2, "If you're wondering why you need these COMPRESSPORT Armforce Ultralight Sleeves if you're doing your favorite sports when the weather gets colder, the answer is to provide you with the thermoregulation you need when exposed to cold air. Featuring gentle compression properties, they precisely target core muscles for stimulated blood flow and support. For running, cycling or hiking these sleeves will hug your hands while protecting and keeping them warm.", "\\images\\products\\COMPRESSPORT Armforce Ultralight.jpg", "COMPRESSPORT Armforce Ultralight", 28.0 },
                    { 25, 2, "Pro Elite Sleeves 2.0, are made with Dri-FIT technology removing sweat for a dry and comfortable feel. Their preformed construction ensures enhanced mobility, while flat seams eliminate friction and irritation.", "\\images\\products\\Nike Pro Elite SLeeves 2.0.jpg", "Nike Pro Elite SLeeves 2.0 ", 29.899999999999999 },
                    { 26, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg", "Nike Pro Elbow Sleeve 3.0", 22.949999999999999 },
                    { 27, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Nike Pro Ankle Sleeve 3.0.jpg", "Nike Pro Ankle Sleeve 3.0", 21.989999999999998 },
                    { 28, 2, "Utilised by the best in the game to improve performance, these form fitting sleeves provide superior support and protection. The compression fit allows a wide range of motion and muscle support. The Dri-FIT fabric wicks moisture away for comfort.Sold in pairs", "\\images\\products\\Jordan Unisex Shooter Sleeves.jpg", "Nike NBA 2.0 Basketball Shooter Sleeve", 34.5 },
                    { 29, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Mcdavid Hex Shooter Arm SLeeve.jpg", "Mcdavid Hex Shooter Arm SLeeve", 30.0 },
                    { 30, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\Mcdavid Power Shooter Arm SLeeve.jpg", "Mcdavid Power Shooter Arm SLeeve", 27.989999999999998 },
                    { 31, 2, "Compressive Basketball Shooter Sleeves for optimal support on every shot.", "\\images\\products\\MCDAVID Elite Compression Arm Sleeve.jpg", "MCDAVID Elite Compression Arm Sleeve", 24.989999999999998 },
                    { 32, 3, "Nike Playground 8P 2.0 G Antetokounmpo Deflated", "\\images\\products\\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg", "Nike Playground 8P 2.0 G Antetokounmpo Deflated", 33.5 },
                    { 33, 3, "The SKLZ Control basketball is the perfect training ball to help athletes improve their dribbling skills. It is made of high quality synthetic leather for indoor and outdoor training.", "\\images\\products\\SKLZ Lightweight Control Basketball Ball.jpg", "SKLZ Lightweight Control Basketball Ball", 39.899999999999999 },
                    { 34, 3, "Nike All Court 8P Z Williamson Deflated", "\\images\\products\\Nike All Court 8P Z Williamson Deflated.jpg", "Nike All Court 8P Z Williamson Deflated", 51.5 },
                    { 35, 3, "Nike Basketball 8P Energy Deflated", "\\images\\products\\Nike Basketball 8P Energy Deflated.jpg", "Nike Basketball 8P Energy Deflated", 57.149999999999999 },
                    { 36, 3, "Nike Elite Tournament 8P Deflated", "\\images\\products\\Nike Elite Tournament 8P Deflated.jpg", "Nike Elite Tournament 8P Deflated", 68.900000000000006 },
                    { 37, 3, "Wilson Nba Official Game Ball Bskt Retail", "\\images\\products\\Wilson Nba Official Game Ball Bskt Retail.jpg", "Wilson Nba Official Game Ball Bskt Retail", 259.0 },
                    { 38, 3, "Nike Championship 8P Deflated", "\\images\\products\\Nike Championship 8P Deflated.jpg", "Nike Championship 8P Deflated", 104.0 },
                    { 39, 3, "Nike Basketball 8P Prm Energy Deflated", "\\images\\products\\Nike Playground 8P 2.0 G Antetokounmpo Deflated.jpg", "Nike Basketball 8P Prm Energy Deflated", 57.509999999999998 },
                    { 40, 3, "Nike Skills", "\\images\\products\\Nike Skills.jpg", "Nike Skills", 13.5 },
                    { 41, 3, "Nike Everyday All Court 8P Graphic Deflated", "\\images\\products\\Nike Everyday All Court 8P Graphic Deflated.jpg", "Nike Everyday All Court 8P Graphic Deflated", 39.899999999999999 },
                    { 42, 3, "Nike Ultimate 2.0 8P Graphic Deflated", "\\images\\products\\Nike Ultimate 2.0 8P Graphic Deflated.jpg", "Nike Ultimate 2.0 8P Graphic Deflated", 44.899999999999999 },
                    { 43, 4, "You don’t need a court to get shots up. Play anywhere with the Team Mini Hoop. Represent your squad with the team paint splatter style. This hoop fits over your doorway with easy assembly for quick set up.", "\\images\\products\\Wilson NBA Milwaukee Bucks Mini Hoop.jpg", "Wilson NBA Milwaukee Bucks Mini Hoop", 27.399999999999999 },
                    { 44, 4, "Basketball Dashboard set", "\\images\\products\\Amila Basketball Dashboard 16Mm.jpg", "Amila Basketball Dashboard 16Mm", 115.90000000000001 },
                    { 45, 4, "Amila Basketball With Hoop Net 2.27-3.05M", "\\images\\products\\Amila Basketball With Hoop Net 2.27-3.05M.jpg", "Amila Basketball With Hoop Net 2.27-3.05M", 279.89999999999998 },
                    { 46, 4, "Amila handheld basket with adjustable height for family play. Ideal for indoor and outdoor use. Dashboard made of durable polycarbonate material with steel edging. The vinyl base is filled with water or sand for guaranteed stability in play.", "\\images\\products\\Amila Basket Semi-Professional, Thickness 3.0Mm.jpg", "Amila Basket Semi-Professional, Thickness 3.0Mm.jpg", 374.89999999999998 },
                    { 47, 4, "SKLZ Pro Mini Hoop System", "\\images\\products\\SKLZ Pro Mini Hoop System.jpg", "SKLZ Pro Mini Hoop System", 219.94999999999999 },
                    { 48, 4, "Portable basketball from the Highlight series of Spalding. With acrylic board width 42 '' and variable height from 2.28 to 3.05 meters so that both the youngest and the oldest basketball fans can enjoy the game!", "\\images\\products\\Spalding 2015 Highlight Portable 42'' Acrylic.jpg", "Spalding 2015 Highlight Portable 42'' Acrylic", 435.60000000000002 },
                    { 49, 4, "Amila Backboard with three-colour net.", "\\images\\products\\Amila Backboard 122 x 85 cm 49197.jpg", "Amila Backboard 122 x 85 cm 49197", 219.90000000000001 },
                    { 50, 4, "Amila Basketball Hoop with Springs & Net.", "\\images\\products\\Amila Basketball Hoop with Springs & Net.jpg", "Amila Basketball Hoop with Springs & Net", 67.900000000000006 },
                    { 51, 4, "Basket wreath with steel tube and spring for pressure absorption from ball hitting and hanging by players. Its diameter is 45cm and includes net in the package. Suitable for every dashboard and basketball to play on the court, garden or cottage.", "\\images\\products\\Amila Basketball Hoop.jpg", "Amila Basketball Hoop", 64.900000000000006 },
                    { 52, 5, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 64, 6, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 74, 7, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 84, 8, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 94, 9, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 104, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 114, 12, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 124, 13, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 134, 14, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 }
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
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

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
