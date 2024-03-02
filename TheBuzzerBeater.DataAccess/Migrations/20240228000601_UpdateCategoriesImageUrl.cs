﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBuzzerBeater.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoriesImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\images\\site\\Jerseys.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "ImageUrl",
                value: "\\images\\site\\Footwear.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\images\\site\\Equipment.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "\\images\\site\\Accessories.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "ImageUrl",
                value: "\\images\\site\\Clearance.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "ImageUrl",
                value: "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "ImageUrl",
                value: "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "ImageUrl",
                value: "\\images\\products\\Nike Pro Elbow Sleeve 3.0.jpg");
        }
    }
}
