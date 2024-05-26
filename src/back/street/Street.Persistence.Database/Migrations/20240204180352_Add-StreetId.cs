using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Streets.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddStreetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "StreetCopies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "StreetCopies");
        }
    }
}
