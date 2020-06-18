using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisConnect.Data.Migrations
{
    public partial class AddUniqueIdentifierinAddressentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueIdentifier",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueIdentifier",
                table: "Addresses");
        }
    }
}
