using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "LocationInergenTanks");

            migrationBuilder.RenameColumn(
                name: "Serial",
                table: "LocationInergenTanks",
                newName: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "LocationInergenTanks",
                newName: "Serial");

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "LocationInergenTanks",
                nullable: true);
        }
    }
}
