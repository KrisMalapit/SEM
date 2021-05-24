using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguisherHeaders_Areas_AreaId",
                table: "FireExtinguisherHeaders");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "FireExtinguisherHeaders",
                newName: "LocationFireExtinguisherId");

            migrationBuilder.RenameIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                newName: "IX_FireExtinguisherHeaders_LocationFireExtinguisherId_CreatedAt_Status");

            migrationBuilder.RenameColumn(
                name: "LocationFireExtinguisherId",
                table: "FireExtinguisherDetails",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherDetails_ItemId",
                table: "FireExtinguisherDetails",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguisherDetails_Items_ItemId",
                table: "FireExtinguisherDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguisherHeaders_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders",
                column: "LocationFireExtinguisherId",
                principalTable: "LocationFireExtinguishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguisherDetails_Items_ItemId",
                table: "FireExtinguisherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguisherHeaders_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropIndex(
                name: "IX_FireExtinguisherDetails_ItemId",
                table: "FireExtinguisherDetails");

            migrationBuilder.RenameColumn(
                name: "LocationFireExtinguisherId",
                table: "FireExtinguisherHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_FireExtinguisherHeaders_LocationFireExtinguisherId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                newName: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "FireExtinguisherDetails",
                newName: "LocationFireExtinguisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguisherHeaders_Areas_AreaId",
                table: "FireExtinguisherHeaders",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
