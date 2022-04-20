using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class RemoveShipId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_Images_ImageId1",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ImageId1",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ImageId1",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ShipId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ImageId",
                table: "Ships",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_Images_ImageId",
                table: "Ships",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_Images_ImageId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ImageId",
                table: "Ships");

            migrationBuilder.AddColumn<int>(
                name: "ImageId1",
                table: "Ships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ImageId1",
                table: "Ships",
                column: "ImageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_Images_ImageId1",
                table: "Ships",
                column: "ImageId1",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
