using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDbandSeedTable : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
