using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport.Persistence.Migrations
{
    public partial class update_company_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "Test" },
                values: new object[] { 1, true, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A1", (byte)1 });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "Test" },
                values: new object[] { 2, true, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "B2", (byte)2 });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "Test" },
                values: new object[] { 3, true, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "C3", (byte)3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
