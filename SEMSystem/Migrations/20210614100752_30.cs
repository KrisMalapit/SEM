using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguisherHeaders_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders");

            migrationBuilder.RenameColumn(
                name: "LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_FireExtinguisherHeaders_LocationFireExtinguisherId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                newName: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.AddColumn<int>(
                name: "LocationFireExtinguisherId",
                table: "FireExtinguisherDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherDetails_LocationFireExtinguisherId",
                table: "FireExtinguisherDetails",
                column: "LocationFireExtinguisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguisherDetails_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherDetails",
                column: "LocationFireExtinguisherId",
                principalTable: "LocationFireExtinguishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguisherDetails_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropIndex(
                name: "IX_FireExtinguisherDetails_LocationFireExtinguisherId",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "LocationFireExtinguisherId",
                table: "FireExtinguisherDetails");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "FireExtinguisherHeaders",
                newName: "LocationFireExtinguisherId");

            migrationBuilder.RenameIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                newName: "IX_FireExtinguisherHeaders_LocationFireExtinguisherId_CreatedAt_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguisherHeaders_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders",
                column: "LocationFireExtinguisherId",
                principalTable: "LocationFireExtinguishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
