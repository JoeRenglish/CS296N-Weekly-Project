using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoryCreator.Migrations
{
    public partial class numbertwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_AppUsers_AuthorAppUserId",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "AuthorAppUserId",
                table: "Stories",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_AuthorAppUserId",
                table: "Stories",
                newName: "IX_Stories_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AppUserId",
                table: "Characters",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AppUsers_AppUserId",
                table: "Characters",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_AppUsers_AppUserId",
                table: "Stories",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AppUsers_AppUserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_AppUsers_AppUserId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AppUserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Stories",
                newName: "AuthorAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_AppUserId",
                table: "Stories",
                newName: "IX_Stories_AuthorAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_AppUsers_AuthorAppUserId",
                table: "Stories",
                column: "AuthorAppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId");
        }
    }
}
