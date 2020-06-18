using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisConnect.Data.Migrations
{
    public partial class SetuniqueconstraintonUniqueIdentifierinAddressentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentifier",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UniqueIdentifier",
                table: "Addresses",
                column: "UniqueIdentifier",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_UniqueIdentifier",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueIdentifier",
                table: "Addresses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
