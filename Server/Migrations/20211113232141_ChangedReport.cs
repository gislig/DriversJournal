using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingJournal.Server.Migrations
{
    public partial class ChangedReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reports");

            migrationBuilder.AddColumn<float>(
                name: "TotalKM",
                table: "Reports",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalKM",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
