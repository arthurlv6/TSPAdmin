using Microsoft.EntityFrameworkCore.Migrations;

namespace TSP.Server.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SubSystems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SubMenuItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SubItemDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "SubSystems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "SubMenuItems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "SubItemDetails");
        }
    }
}
