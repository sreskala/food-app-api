using Microsoft.EntityFrameworkCore.Migrations;

namespace food_tracker_api.Migrations
{
    public partial class UserCharacterRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StoragePlaces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoragePlaces_UserId",
                table: "StoragePlaces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoragePlaces_Users_UserId",
                table: "StoragePlaces",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoragePlaces_Users_UserId",
                table: "StoragePlaces");

            migrationBuilder.DropIndex(
                name: "IX_StoragePlaces_UserId",
                table: "StoragePlaces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoragePlaces");
        }
    }
}
