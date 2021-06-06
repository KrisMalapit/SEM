using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentStatus",
                table: "InergenTankHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentStatus",
                table: "FireHydrantHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentStatus",
                table: "FireExtinguisherHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentStatus",
                table: "EmergencyLightHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentStatus",
                table: "BicycleEntryHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "InergenTankHeaders");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "FireHydrantHeaders");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "EmergencyLightHeaders");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "BicycleEntryHeaders");
        }
    }
}
