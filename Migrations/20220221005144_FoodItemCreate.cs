using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace food_tracker_api.Migrations
{
    public partial class FoodItemCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsPerishable = table.Column<bool>(type: "bit", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndividualPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StoragePlaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItem_StoragePlaces_StoragePlaceId",
                        column: x => x.StoragePlaceId,
                        principalTable: "StoragePlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItem_StoragePlaceId",
                table: "FoodItem",
                column: "StoragePlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItem");
        }
    }
}
