using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BicycleEntryHeaders_BicycleId_CreatedAt_Status",
                table: "BicycleEntryHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "BicycleEntryHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BicycleEntryHeaders_BicycleId",
                table: "BicycleEntryHeaders",
                column: "BicycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BicycleEntryHeaders_BicycleId",
                table: "BicycleEntryHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "BicycleEntryHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BicycleEntryHeaders_BicycleId_CreatedAt_Status",
                table: "BicycleEntryHeaders",
                columns: new[] { "BicycleId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");
        }
    }
}
