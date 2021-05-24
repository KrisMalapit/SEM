using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId",
                table: "InergenTankHeaders");

            migrationBuilder.DropIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId",
                table: "FireHydrantHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "InergenTankHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireHydrantHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId_CreatedAt_Status",
                table: "InergenTankHeaders",
                columns: new[] { "LocationInergenTankId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId_CreatedAt_Status",
                table: "FireHydrantHeaders",
                columns: new[] { "LocationFireHydrantId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId_CreatedAt_Status",
                table: "InergenTankHeaders");

            migrationBuilder.DropIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId_CreatedAt_Status",
                table: "FireHydrantHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "InergenTankHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireHydrantHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId",
                table: "InergenTankHeaders",
                column: "LocationInergenTankId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId",
                table: "FireHydrantHeaders",
                column: "LocationFireHydrantId");
        }
    }
}
