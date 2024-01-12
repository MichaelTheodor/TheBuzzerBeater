using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDbAndSeedTableandAddProductToDbAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 12, 12, "Shoes" },
                    { 13, 13, "Socks" },
                    { 14, 14, "Stickers" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-boston-celtics.jpg", "back-me-up-cup-nba-boston-celtics", 6.0 },
                    { 2, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-bucks", "back-me-up-cup-nba-bucks", 6.0 },
                    { 3, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-bulls", "back-me-up-cup-nba-bulls", 6.0 },
                    { 4, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-la-lakers (1)", "back-me-up-cup-nba-la-lakers", 6.0 },
                    { 5, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-la-lakers", "back-me-up-cup-nba-la-lakers-second", 6.0 },
                    { 6, 10, "Ceramic mugs and cups with your favorite NBA team", "@/images/product/back-me-up-koupa-keramapli-nba-logo", "back-me-up-cup-nba-logo", 5.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
