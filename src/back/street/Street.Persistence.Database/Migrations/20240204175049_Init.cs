using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Streets.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StreetCopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetCopies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streets_Id",
                table: "Streets",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StreetCopies");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
