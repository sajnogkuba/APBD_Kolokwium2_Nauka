using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Przykład2.Migrations
{
    /// <inheritdoc />
    public partial class adddatatotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Muzyk",
                columns: new[] { "id_muzyk", "Imie", "Nazwisko", "Pseudonim" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "Kowal" },
                    { 2, "Anna", "Nowak", "Nowak" },
                    { 3, "Piotr", "Wiśniewski", "Wiśnia" }
                });

            migrationBuilder.InsertData(
                table: "Wytwornia",
                columns: new[] { "IdWytwornia", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Sony Music" },
                    { 2, "Universal Music" },
                    { 3, "Warner Music" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "DataWydania", "IdWytwornia", "NazwaAlbumu" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Album1" },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Album2" },
                    { 3, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Album3" }
                });

            migrationBuilder.InsertData(
                table: "Utwor",
                columns: new[] { "IdUtwor", "CzasTrwania", "IdAlbum", "NazwaUtworu" },
                values: new object[,]
                {
                    { 1, 3.5f, 2, "Piosenka1" },
                    { 2, 4.2f, 1, "Piosenka2" },
                    { 3, 2.8f, 1, "Piosenka3" }
                });

            migrationBuilder.InsertData(
                table: "WykonawcaUtwor",
                columns: new[] { "IdWMuzyk", "IdWUtwor" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WykonawcaUtwor",
                keyColumns: new[] { "IdWMuzyk", "IdWUtwor" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "WykonawcaUtwor",
                keyColumns: new[] { "IdWMuzyk", "IdWUtwor" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "WykonawcaUtwor",
                keyColumns: new[] { "IdWMuzyk", "IdWUtwor" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Muzyk",
                keyColumn: "id_muzyk",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Muzyk",
                keyColumn: "id_muzyk",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Muzyk",
                keyColumn: "id_muzyk",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utwor",
                keyColumn: "IdUtwor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utwor",
                keyColumn: "IdUtwor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utwor",
                keyColumn: "IdUtwor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wytwornia",
                keyColumn: "IdWytwornia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wytwornia",
                keyColumn: "IdWytwornia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wytwornia",
                keyColumn: "IdWytwornia",
                keyValue: 2);
        }
    }
}
