using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TennisConnect.Data.Migrations
{
    public partial class RemovedContactDetailsandreplacedUserNamewithEmailAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Profiles_ProfileId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_ContactDetails_ContactDetailsId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ContactDetailsId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_ProfileId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Clubs");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ClubId",
                table: "Profiles",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Clubs_ClubId",
                table: "Profiles",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Clubs_ClubId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ClubId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailsId",
                table: "Profiles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Clubs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ContactDetailsId",
                table: "Profiles",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ProfileId",
                table: "Clubs",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Profiles_ProfileId",
                table: "Clubs",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ContactDetails_ContactDetailsId",
                table: "Profiles",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
