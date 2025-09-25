using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport.Persistence.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Test = table.Column<byte>(type: "tinyint", maxLength: 5, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    StatusMode = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "Active", "Description", "License", "Status", "StatusMode", "Type" },
                values: new object[,]
                {
                    { 1, true, "Description for transport 1", null, 1, null, null },
                    { 2, true, "Description for transport 2", null, 1, null, null },
                    { 3, true, "Description for transport 3", null, 1, null, null },
                    { 4, true, "Description for transport 4", null, 1, null, null },
                    { 5, true, "Description for transport 5", null, 1, null, null },
                    { 6, true, "Description for transport 6", null, 1, null, null },
                    { 7, true, "Description for transport 7", null, 1, null, null },
                    { 8, true, "Description for transport 8", null, 1, null, null },
                    { 9, true, "Description for transport 9", null, 1, null, null },
                    { 10, true, "Description for transport 10", null, 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Id",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Id",
                table: "Transports",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
