using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ItemLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "ItemLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ItemLogs");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "ItemLogs");
        }
    }
}
