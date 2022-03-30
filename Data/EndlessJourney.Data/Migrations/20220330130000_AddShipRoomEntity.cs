using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class AddShipRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Ships_ShipId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ShipId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ShipId",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "ShipRooms",
                columns: table => new
                {
                    ShipId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipRooms", x => new { x.ShipId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_ShipRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipRooms_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipRooms_IsDeleted",
                table: "ShipRooms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ShipRooms_RoomId",
                table: "ShipRooms",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipRooms");

            migrationBuilder.AddColumn<int>(
                name: "ShipId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ShipId",
                table: "Rooms",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Ships_ShipId",
                table: "Rooms",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
