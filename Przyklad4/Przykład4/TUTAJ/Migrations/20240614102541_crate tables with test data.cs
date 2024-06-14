using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class cratetableswithtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    current_weig = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<int>(type: "int", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    weig = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Backpack_Slots",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_item = table.Column<int>(type: "int", nullable: false),
                    FK_character = table.Column<int>(type: "int", nullable: false),
                    ItemPK = table.Column<int>(type: "int", nullable: false),
                    CharacterPK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack_Slots", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Characters_CharacterPK",
                        column: x => x.CharacterPK,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Slots_Items_ItemPK",
                        column: x => x.ItemPK,
                        principalTable: "Items",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters_Titles",
                columns: table => new
                {
                    FK_character = table.Column<int>(type: "int", nullable: false),
                    FK_title = table.Column<int>(type: "int", nullable: false),
                    aquire_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CharacterPK = table.Column<int>(type: "int", nullable: false),
                    TitlePK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters_Titles", x => new { x.FK_character, x.FK_title });
                    table.ForeignKey(
                        name: "FK_Characters_Titles_Characters_CharacterPK",
                        column: x => x.CharacterPK,
                        principalTable: "Characters",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Titles_Titles_TitlePK",
                        column: x => x.TitlePK,
                        principalTable: "Titles",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "PK", "current_weig", "first_name", "last_name", "max_weight", "money" },
                values: new object[,]
                {
                    { 1, 100, "Siwy", "Geralt", 300, 100 },
                    { 2, 0, "TestFirstName", "TestLastName", 300, 150 },
                    { 3, 0, "TestFirstName2", "TestLastName2", 400, 200 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "PK", "name", "weig" },
                values: new object[,]
                {
                    { 1, "Miecz na potwory", 50 },
                    { 2, "TestItem2", 20 },
                    { 3, "TestItem3", 30 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "PK", "name" },
                values: new object[,]
                {
                    { 1, "Biały Wilk" },
                    { 2, "Gwynbleidd" },
                    { 3, "TestTitle3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_CharacterPK",
                table: "Backpack_Slots",
                column: "CharacterPK");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_ItemPK",
                table: "Backpack_Slots",
                column: "ItemPK");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_CharacterPK",
                table: "Characters_Titles",
                column: "CharacterPK");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_TitlePK",
                table: "Characters_Titles",
                column: "TitlePK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack_Slots");

            migrationBuilder.DropTable(
                name: "Characters_Titles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
