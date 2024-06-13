using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Przykład3.Migrations
{
    /// <inheritdoc />
    public partial class addtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoatStandard",
                columns: new[] { "IdBoatStandard", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Test" },
                    { 2, 2, "Test2" },
                    { 3, 3, "Test3" }
                });

            migrationBuilder.InsertData(
                table: "ClientCategory",
                columns: new[] { "IdClientCategory", "DiscountPerc", "Name" },
                values: new object[,]
                {
                    { 1, 10, "Test" },
                    { 2, 20, "Test2" },
                    { 3, 30, "Test3" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Birthday", "IdClientCategory", "Email", "LastName", "Name", "Pesel" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "test@gmail.com", "Test", "Test", "54345678901" },
                    { 2, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "test2@gmail.com", "Test2", "Test2", "12345678901" },
                    { 3, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "tes3@gmail.com", "Test3", "Test3", "69345678901" }
                });

            migrationBuilder.InsertData(
                table: "Sailboat",
                columns: new[] { "IdSailboat", "IdBoatStandard", "Capacity", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "Test", "Test", 100m },
                    { 2, 2, 2, "Test2", "Test2", 200m },
                    { 3, 3, 3, "Test3", "Test3", 300m }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "IdReservation", "IdBoatStandard", "CancelReason", "Capacity", "IdClient", "DateFrom", "DateTo", "Fulfilled", "NumOfBoats", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 100m },
                    { 2, 2, null, 3, 2, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 300m },
                    { 3, 3, "TEST", 13, 1, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 1300m }
                });

            migrationBuilder.InsertData(
                table: "Saleboat_Reservation",
                columns: new[] { "IdReservation", "IdSailboat" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Saleboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 2);
        }
    }
}
