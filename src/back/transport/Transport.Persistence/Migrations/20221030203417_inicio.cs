using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transport.Persistence.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "Description", "License", "Status", "StatusMode", "Type" },
                values: new object[,]
                {
                    { 1, "Description for transport 1", null, 1, null, null },
                    { 2, "Description for transport 2", null, 1, null, null },
                    { 3, "Description for transport 3", null, 1, null, null },
                    { 4, "Description for transport 4", null, 1, null, null },
                    { 5, "Description for transport 5", null, 1, null, null },
                    { 6, "Description for transport 6", null, 1, null, null },
                    { 7, "Description for transport 7", null, 1, null, null },
                    { 8, "Description for transport 8", null, 1, null, null },
                    { 9, "Description for transport 9", null, 1, null, null },
                    { 10, "Description for transport 10", null, 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Id",
                table: "Transports",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
