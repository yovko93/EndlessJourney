using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class ChangeDestinationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CityId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Destinations",
                newName: "StartPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations",
                newName: "IX_Destinations_StartPointId");

            migrationBuilder.AddColumn<int>(
                name: "EndPointId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_EndPointId",
                table: "Destinations",
                column: "EndPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_EndPointId",
                table: "Destinations",
                column: "EndPointId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_StartPointId",
                table: "Destinations",
                column: "StartPointId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_EndPointId",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_StartPointId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_EndPointId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "EndPointId",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "StartPointId",
                table: "Destinations",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_StartPointId",
                table: "Destinations",
                newName: "IX_Destinations_CityId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CityId",
                table: "Trips",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
