using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class AddShipProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Crew",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Crew",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Ships");
        }
    }
}
