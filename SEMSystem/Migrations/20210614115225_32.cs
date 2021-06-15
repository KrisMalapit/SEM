using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyLightHeaders_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightHeaders");

            migrationBuilder.RenameColumn(
                name: "LocationEmergencyLightId",
                table: "EmergencyLightHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyLightHeaders_LocationEmergencyLightId_CreatedAt_Status",
                table: "EmergencyLightHeaders",
                newName: "IX_EmergencyLightHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireExtinguisherHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationEmergencyLightId",
                table: "EmergencyLightDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                columns: new[] { "AreaId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyLightDetails_LocationEmergencyLightId",
                table: "EmergencyLightDetails",
                column: "LocationEmergencyLightId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyLightDetails_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightDetails",
                column: "LocationEmergencyLightId",
                principalTable: "LocationEmergencyLights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyLightDetails_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightDetails");

            migrationBuilder.DropIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyLightDetails_LocationEmergencyLightId",
                table: "EmergencyLightDetails");

            migrationBuilder.DropColumn(
                name: "LocationEmergencyLightId",
                table: "EmergencyLightDetails");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "EmergencyLightHeaders",
                newName: "LocationEmergencyLightId");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyLightHeaders_AreaId_CreatedAt_Status",
                table: "EmergencyLightHeaders",
                newName: "IX_EmergencyLightHeaders_LocationEmergencyLightId_CreatedAt_Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireExtinguisherHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyLightHeaders_LocationEmergencyLights_LocationEmergencyLightId",
                table: "EmergencyLightHeaders",
                column: "LocationEmergencyLightId",
                principalTable: "LocationEmergencyLights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
