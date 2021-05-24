using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyLightHeaders_Areas_AreaId",
                table: "EmergencyLightHeaders");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "EmergencyLightHeaders",
                newName: "LocationEmergencyLightId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyLightHeaders_AreaId_CreatedAt_Status",
                table: "EmergencyLightHeaders",
                newName: "IX_EmergencyLightHeaders_LocationEmergencyLightId_CreatedAt_Status");

            migrationBuilder.RenameColumn(
                name: "LocationEmergencyLightId",
                table: "EmergencyLightDetails",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyLightDetails_ItemId",
                table: "EmergencyLightDetails",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyLightDetails_Items_ItemId",
                table: "EmergencyLightDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyLightHeaders_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightHeaders",
                column: "LocationEmergencyLightId",
                principalTable: "LocationEmergencyLights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyLightDetails_Items_ItemId",
                table: "EmergencyLightDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyLightHeaders_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightHeaders");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyLightDetails_ItemId",
                table: "EmergencyLightDetails");

            migrationBuilder.RenameColumn(
                name: "LocationEmergencyLightId",
                table: "EmergencyLightHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyLightHeaders_LocationEmergencyLightId_CreatedAt_Status",
                table: "EmergencyLightHeaders",
                newName: "IX_EmergencyLightHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "EmergencyLightDetails",
                newName: "LocationEmergencyLightId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyLightHeaders_Areas_AreaId",
                table: "EmergencyLightHeaders",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
