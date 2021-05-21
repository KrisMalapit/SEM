using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InspectedBy",
                table: "InergenTankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotedBy",
                table: "InergenTankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "InergenTankDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspectedBy",
                table: "FireHydrantDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotedBy",
                table: "FireHydrantDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "FireHydrantDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspectedBy",
                table: "EmergencyLightDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotedBy",
                table: "EmergencyLightDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "EmergencyLightDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "InergenTankDetails");

            migrationBuilder.DropColumn(
                name: "NotedBy",
                table: "InergenTankDetails");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "InergenTankDetails");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "FireHydrantDetails");

            migrationBuilder.DropColumn(
                name: "NotedBy",
                table: "FireHydrantDetails");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "FireHydrantDetails");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "EmergencyLightDetails");

            migrationBuilder.DropColumn(
                name: "NotedBy",
                table: "EmergencyLightDetails");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "EmergencyLightDetails");
        }
    }
}
