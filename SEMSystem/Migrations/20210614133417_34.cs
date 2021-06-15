using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InergenTankHeaders_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankHeaders");

            migrationBuilder.RenameColumn(
                name: "LocationInergenTankId",
                table: "InergenTankHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId_CreatedAt_Status",
                table: "InergenTankHeaders",
                newName: "IX_InergenTankHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.AddColumn<int>(
                name: "LocationInergenTankId",
                table: "InergenTankDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankDetails_LocationInergenTankId",
                table: "InergenTankDetails",
                column: "LocationInergenTankId");

            migrationBuilder.AddForeignKey(
                name: "FK_InergenTankDetails_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankDetails",
                column: "LocationInergenTankId",
                principalTable: "LocationInergenTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InergenTankDetails_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankDetails");

            migrationBuilder.DropIndex(
                name: "IX_InergenTankDetails_LocationInergenTankId",
                table: "InergenTankDetails");

            migrationBuilder.DropColumn(
                name: "LocationInergenTankId",
                table: "InergenTankDetails");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "InergenTankHeaders",
                newName: "LocationInergenTankId");

            migrationBuilder.RenameIndex(
                name: "IX_InergenTankHeaders_AreaId_CreatedAt_Status",
                table: "InergenTankHeaders",
                newName: "IX_InergenTankHeaders_LocationInergenTankId_CreatedAt_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_InergenTankHeaders_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankHeaders",
                column: "LocationInergenTankId",
                principalTable: "LocationInergenTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
