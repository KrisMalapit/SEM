using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InspectedBy",
                table: "FireExtinguisherDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotedBy",
                table: "FireExtinguisherDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedBy",
                table: "FireExtinguisherDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "NotedBy",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "ReviewedBy",
                table: "FireExtinguisherDetails");
        }
    }
}
