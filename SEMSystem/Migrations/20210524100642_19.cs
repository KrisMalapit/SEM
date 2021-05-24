using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InergenTankHeaders_Areas_AreaId",
                table: "InergenTankHeaders");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "InergenTankHeaders",
                newName: "LocationInergenTankId");

            migrationBuilder.RenameIndex(
                name: "IX_InergenTankHeaders_AreaId",
                table: "InergenTankHeaders",
                newName: "IX_InergenTankHeaders_LocationInergenTankId");

            migrationBuilder.RenameColumn(
                name: "LocationInergenTankId",
                table: "InergenTankDetails",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InergenTankDetails_ItemId",
                table: "InergenTankDetails",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InergenTankDetails_Items_ItemId",
                table: "InergenTankDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InergenTankHeaders_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankHeaders",
                column: "LocationInergenTankId",
                principalTable: "LocationInergenTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InergenTankDetails_Items_ItemId",
                table: "InergenTankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_InergenTankHeaders_LocationInergenTanks_LocationInergenTankId",
                table: "InergenTankHeaders");

            migrationBuilder.DropIndex(
                name: "IX_InergenTankDetails_ItemId",
                table: "InergenTankDetails");

            migrationBuilder.RenameColumn(
                name: "LocationInergenTankId",
                table: "InergenTankHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_InergenTankHeaders_LocationInergenTankId",
                table: "InergenTankHeaders",
                newName: "IX_InergenTankHeaders_AreaId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "InergenTankDetails",
                newName: "LocationInergenTankId");

            migrationBuilder.AddForeignKey(
                name: "FK_InergenTankHeaders_Areas_AreaId",
                table: "InergenTankHeaders",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
