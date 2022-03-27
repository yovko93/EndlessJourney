namespace EndlessJourney.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_CityId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CityId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Destinations");
        }
    }
}
