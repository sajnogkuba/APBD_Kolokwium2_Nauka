using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Przykład4.Migrations
{
    /// <inheritdoc />
    public partial class addtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWei = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "backpacks",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ItemId1 = table.Column<int>(type: "int", nullable: false),
                    CharacterId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_backpacks", x => new { x.CharacterId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_backpacks_characters_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_backpacks_items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character_titles",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_titles", x => new { x.CharacterId, x.TitleId });
                    table.ForeignKey(
                        name: "FK_character_titles_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_titles_titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "Id", "CurrentWei", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 0, "TestCharacterFirstName", "TestCharacterLastName", 100 },
                    { 2, 20, "TestCharacterFirstName2", "TestCharacterLastName2", 120 },
                    { 3, 30, "TestCharacterFirstName3", "TestCharacterLastName3", 130 }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "TestItem", 10 },
                    { 2, "TestItem2", 20 },
                    { 3, "TestItem3", 30 }
                });

            migrationBuilder.InsertData(
                table: "titles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TestTitle" },
                    { 2, "TestTitle2" },
                    { 3, "TestTitle3" }
                });

            migrationBuilder.InsertData(
                table: "character_titles",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 13, 17, 40, 32, 298, DateTimeKind.Local).AddTicks(7930) },
                    { 2, 2, new DateTime(2024, 6, 13, 17, 40, 32, 316, DateTimeKind.Local).AddTicks(700) },
                    { 3, 3, new DateTime(2024, 6, 13, 17, 40, 32, 316, DateTimeKind.Local).AddTicks(720) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_CharacterId1",
                table: "backpacks",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_ItemId1",
                table: "backpacks",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_character_titles_TitleId",
                table: "character_titles",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backpacks");

            migrationBuilder.DropTable(
                name: "character_titles");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "titles");
        }
    }
}
