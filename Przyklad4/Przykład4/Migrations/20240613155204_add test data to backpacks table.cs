using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Przykład4.Migrations
{
    /// <inheritdoc />
    public partial class addtestdatatobackpackstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 52, 4, 625, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 52, 4, 643, DateTimeKind.Local).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 3, 3 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 52, 4, 643, DateTimeKind.Local).AddTicks(950));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 50, 40, 694, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 50, 40, 711, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 3, 3 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 50, 40, 711, DateTimeKind.Local).AddTicks(4790));
        }
    }
}
