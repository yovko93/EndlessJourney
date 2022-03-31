using Microsoft.EntityFrameworkCore.Migrations;

namespace EndlessJourney.Data.Migrations
{
    public partial class AddImagePathName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathName",
                table: "Images");
        }
    }
}
