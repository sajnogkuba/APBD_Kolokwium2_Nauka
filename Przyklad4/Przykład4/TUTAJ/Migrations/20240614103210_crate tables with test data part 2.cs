using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class cratetableswithtestdatapart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Slots_Characters_CharacterPK",
                table: "Backpack_Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Slots_Items_ItemPK",
                table: "Backpack_Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Titles_Characters_CharacterPK",
                table: "Characters_Titles");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Titles_Titles_TitlePK",
                table: "Characters_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Titles_CharacterPK",
                table: "Characters_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Titles_TitlePK",
                table: "Characters_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Backpack_Slots_CharacterPK",
                table: "Backpack_Slots");

            migrationBuilder.DropIndex(
                name: "IX_Backpack_Slots_ItemPK",
                table: "Backpack_Slots");

            migrationBuilder.DropColumn(
                name: "CharacterPK",
                table: "Characters_Titles");

            migrationBuilder.DropColumn(
                name: "TitlePK",
                table: "Characters_Titles");

            migrationBuilder.DropColumn(
                name: "CharacterPK",
                table: "Backpack_Slots");

            migrationBuilder.DropColumn(
                name: "ItemPK",
                table: "Backpack_Slots");

            migrationBuilder.InsertData(
                table: "Backpack_Slots",
                columns: new[] { "PK", "FK_character", "FK_item" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Characters_Titles",
                columns: new[] { "FK_character", "FK_title", "aquire_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 14, 12, 32, 9, 898, DateTimeKind.Local).AddTicks(5070) },
                    { 1, 2, new DateTime(2024, 6, 14, 12, 32, 9, 915, DateTimeKind.Local).AddTicks(5470) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_FK_title",
                table: "Characters_Titles",
                column: "FK_title");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_FK_character",
                table: "Backpack_Slots",
                column: "FK_character");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_FK_item",
                table: "Backpack_Slots",
                column: "FK_item");

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Slots_Characters_FK_character",
                table: "Backpack_Slots",
                column: "FK_character",
                principalTable: "Characters",
                principalColumn: "PK");

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Slots_Items_FK_item",
                table: "Backpack_Slots",
                column: "FK_item",
                principalTable: "Items",
                principalColumn: "PK");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Titles_Characters_FK_character",
                table: "Characters_Titles",
                column: "FK_character",
                principalTable: "Characters",
                principalColumn: "PK");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Titles_Titles_FK_title",
                table: "Characters_Titles",
                column: "FK_title",
                principalTable: "Titles",
                principalColumn: "PK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Slots_Characters_FK_character",
                table: "Backpack_Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Backpack_Slots_Items_FK_item",
                table: "Backpack_Slots");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Titles_Characters_FK_character",
                table: "Characters_Titles");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Titles_Titles_FK_title",
                table: "Characters_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Characters_Titles_FK_title",
                table: "Characters_Titles");

            migrationBuilder.DropIndex(
                name: "IX_Backpack_Slots_FK_character",
                table: "Backpack_Slots");

            migrationBuilder.DropIndex(
                name: "IX_Backpack_Slots_FK_item",
                table: "Backpack_Slots");

            migrationBuilder.DeleteData(
                table: "Backpack_Slots",
                keyColumn: "PK",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Backpack_Slots",
                keyColumn: "PK",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters_Titles",
                keyColumns: new[] { "FK_character", "FK_title" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Characters_Titles",
                keyColumns: new[] { "FK_character", "FK_title" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.AddColumn<int>(
                name: "CharacterPK",
                table: "Characters_Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitlePK",
                table: "Characters_Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharacterPK",
                table: "Backpack_Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemPK",
                table: "Backpack_Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_CharacterPK",
                table: "Characters_Titles",
                column: "CharacterPK");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titles_TitlePK",
                table: "Characters_Titles",
                column: "TitlePK");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_CharacterPK",
                table: "Backpack_Slots",
                column: "CharacterPK");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slots_ItemPK",
                table: "Backpack_Slots",
                column: "ItemPK");

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Slots_Characters_CharacterPK",
                table: "Backpack_Slots",
                column: "CharacterPK",
                principalTable: "Characters",
                principalColumn: "PK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Backpack_Slots_Items_ItemPK",
                table: "Backpack_Slots",
                column: "ItemPK",
                principalTable: "Items",
                principalColumn: "PK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Titles_Characters_CharacterPK",
                table: "Characters_Titles",
                column: "CharacterPK",
                principalTable: "Characters",
                principalColumn: "PK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Titles_Titles_TitlePK",
                table: "Characters_Titles",
                column: "TitlePK",
                principalTable: "Titles",
                principalColumn: "PK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
