using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "LocationFireExtinguishers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "LocationFireExtinguishers");

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "LocationFireExtinguishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "LocationFireExtinguishers",
                nullable: true);
        }
    }
}
