using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-boston-celtics", 6.0 },
                    { 2, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-bucks", 6.0 },
                    { 3, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-bulls", 6.0 },
                    { 4, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-la-lakers", 6.0 },
                    { 5, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-la-lakers-second", 6.0 },
                    { 6, 10, "Ceramic mugs and cups with your favorite NBA team", "", "back-me-up-cup-nba-logo", 5.0 }
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
        }
    }
}
