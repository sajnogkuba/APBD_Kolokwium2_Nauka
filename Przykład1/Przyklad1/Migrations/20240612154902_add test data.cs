using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Przyklad1.Migrations
{
    /// <inheritdoc />
    public partial class addtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[,]
                {
                    { 1, "TestCategory" },
                    { 2, "TestCategory2" },
                    { 3, "TestCategory3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[,]
                {
                    { 1, 0.3m, 0.2m, "TestProduct", 0.4m, 0.1m },
                    { 2, 0.7m, 0.6m, "TestProduct2", 0.8m, 0.5m },
                    { 3, 1.1m, 1m, "TestProduct3", 1.2m, 0.9m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "last_name", "phone", "FK_role" },
                values: new object[,]
                {
                    { 1, "test@gmail.com", "John", "Doe", "123456789", 1 },
                    { 2, "test2@gmail.com", "Jane", "Doe", "987654321", 2 },
                    { 3, "test3@gmail.com", "John", "Smith", "666666789", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products_Categories",
                columns: new[] { "FK_category", "FK_product" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_account", "FK_product", "amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 3);
        }
    }
}
