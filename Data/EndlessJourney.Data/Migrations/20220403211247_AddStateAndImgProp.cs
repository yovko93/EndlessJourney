using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class AddStateAndImgProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cities");
        }
    }
}
