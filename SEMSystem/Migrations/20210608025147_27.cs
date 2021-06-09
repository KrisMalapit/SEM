using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "InergenTankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FireHydrantDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FireExtinguisherDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "EmergencyLightDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BicycleEntryDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "InergenTankDetails");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FireHydrantDetails");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "EmergencyLightDetails");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BicycleEntryDetails");
        }
    }
}
