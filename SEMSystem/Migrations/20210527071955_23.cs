using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "InergenTankHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "FireExtinguisherHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "EmergencyLightHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "BicycleEntryHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "InergenTankHeaders");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "EmergencyLightHeaders");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "BicycleEntryHeaders");
        }
    }
}
