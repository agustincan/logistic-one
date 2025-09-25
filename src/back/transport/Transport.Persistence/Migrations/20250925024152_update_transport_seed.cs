using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport.Persistence.Migrations
{
    public partial class update_transport_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "License", "Type" },
                values: new object[] { "Transport 1", "ABC123", 1 });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "License", "StatusMode", "Type" },
                values: new object[] { "Transport 2", "DEF456", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "Description", "License", "Status", "StatusMode", "Type" },
                values: new object[] { false, "Transport 3", "GHI789", 2, 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "License", "Type" },
                values: new object[] { "Description for transport 1", null, null });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "License", "StatusMode", "Type" },
                values: new object[] { "Description for transport 2", null, null, null });

            migrationBuilder.UpdateData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Active", "Description", "License", "Status", "StatusMode", "Type" },
                values: new object[] { true, "Description for transport 3", null, 1, null, null });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "Active", "Description", "License", "Status", "StatusMode", "Type" },
                values: new object[,]
                {
                    { 4, true, "Description for transport 4", null, 1, null, null },
                    { 5, true, "Description for transport 5", null, 1, null, null },
                    { 6, true, "Description for transport 6", null, 1, null, null },
                    { 7, true, "Description for transport 7", null, 1, null, null },
                    { 8, true, "Description for transport 8", null, 1, null, null },
                    { 9, true, "Description for transport 9", null, 1, null, null },
                    { 10, true, "Description for transport 10", null, 1, null, null }
                });
        }
    }
}
