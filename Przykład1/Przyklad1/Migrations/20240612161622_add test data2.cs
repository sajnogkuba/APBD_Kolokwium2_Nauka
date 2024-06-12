using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przyklad1.Migrations
{
    /// <inheritdoc />
    public partial class addtestdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_account", "FK_product", "amount" },
                values: new object[] { 1, 2, 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
