using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisConnect.Data.Migrations
{
    public partial class AddFriendentitymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:friend_request_flag", "none,approved,rejected")
                .Annotation("Npgsql:Enum:rating", "beginner,improver,intermediate,experienced")
                .OldAnnotation("Npgsql:Enum:rating", "beginner,improver,intermediate,experienced");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    RequestedById = table.Column<int>(nullable: false),
                    RequestedToId = table.Column<int>(nullable: false),
                    RequestTime = table.Column<DateTime>(nullable: true),
                    BecameFriendsTime = table.Column<DateTime>(nullable: true),
                    FriendRequestFlag = table.Column<FriendRequestFlag>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.RequestedById, x.RequestedToId });
                    table.ForeignKey(
                        name: "FK_Friends_Profiles_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_Profiles_RequestedToId",
                        column: x => x.RequestedToId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_RequestedToId",
                table: "Friends",
                column: "RequestedToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:rating", "beginner,improver,intermediate,experienced")
                .OldAnnotation("Npgsql:Enum:friend_request_flag", "none,approved,rejected")
                .OldAnnotation("Npgsql:Enum:rating", "beginner,improver,intermediate,experienced");
        }
    }
}
