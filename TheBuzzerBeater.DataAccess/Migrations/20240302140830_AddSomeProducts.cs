using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 94);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 53, 15, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 54, 16, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 55, 17, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 56, 18, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 56);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 64, 15, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 74, 16, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 84, 17, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 },
                    { 94, 18, "This pump is light and easy to use so you can take it with you wherever you go. It is made for all basketballs.", "\\images\\products\\Wilson NBA DVR Pump Kit.jpg", "Wilson NBA DVR Pump Kit", 18.600000000000001 }
                });
        }
    }
}
