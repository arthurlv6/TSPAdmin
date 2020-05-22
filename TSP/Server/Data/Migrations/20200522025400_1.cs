﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TSP.Server.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SubSystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubMenuItems_SubSystems_SubSystemId",
                        column: x => x.SubSystemId,
                        principalTable: "SubSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SubMenuItemId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Paragraph = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItemDetails_SubMenuItems_SubMenuItemId",
                        column: x => x.SubMenuItemId,
                        principalTable: "SubMenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubItemDetails_SubMenuItemId",
                table: "SubItemDetails",
                column: "SubMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenuItems_SubSystemId",
                table: "SubMenuItems",
                column: "SubSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubItemDetails");

            migrationBuilder.DropTable(
                name: "SubMenuItems");

            migrationBuilder.DropTable(
                name: "SubSystems");
        }
    }
}
