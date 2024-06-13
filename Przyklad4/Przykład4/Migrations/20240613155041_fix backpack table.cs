using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przykład4.Migrations
{
    /// <inheritdoc />
    public partial class fixbackpacktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_backpacks_characters_CharacterId1",
                table: "backpacks");

            migrationBuilder.DropForeignKey(
                name: "FK_backpacks_items_ItemId1",
                table: "backpacks");

            migrationBuilder.DropIndex(
                name: "IX_backpacks_CharacterId1",
                table: "backpacks");

            migrationBuilder.DropIndex(
                name: "IX_backpacks_ItemId1",
                table: "backpacks");

            migrationBuilder.DropColumn(
                name: "CharacterId1",
                table: "backpacks");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "backpacks");

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

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_ItemId",
                table: "backpacks",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_backpacks_characters_CharacterId",
                table: "backpacks",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_backpacks_items_ItemId",
                table: "backpacks",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_backpacks_characters_CharacterId",
                table: "backpacks");

            migrationBuilder.DropForeignKey(
                name: "FK_backpacks_items_ItemId",
                table: "backpacks");

            migrationBuilder.DropIndex(
                name: "IX_backpacks_ItemId",
                table: "backpacks");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId1",
                table: "backpacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "backpacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 40, 32, 298, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 40, 32, 316, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 3, 3 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 13, 17, 40, 32, 316, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_CharacterId1",
                table: "backpacks",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_ItemId1",
                table: "backpacks",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_backpacks_characters_CharacterId1",
                table: "backpacks",
                column: "CharacterId1",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_backpacks_items_ItemId1",
                table: "backpacks",
                column: "ItemId1",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
