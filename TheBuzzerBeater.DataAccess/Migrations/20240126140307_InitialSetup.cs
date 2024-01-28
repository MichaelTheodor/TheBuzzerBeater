﻿using System;
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
                    { 23, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 24, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 25, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 26, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 27, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 28, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 29, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 30, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 31, 11, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 32, 12, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 33, 13, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 34, 14, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 }
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
