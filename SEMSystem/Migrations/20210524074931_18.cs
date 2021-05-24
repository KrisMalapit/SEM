using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireHydrantHeaders_Areas_AreaId",
                table: "FireHydrantHeaders");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "FireHydrantHeaders",
                newName: "LocationFireHydrantId");

            migrationBuilder.RenameIndex(
                name: "IX_FireHydrantHeaders_AreaId",
                table: "FireHydrantHeaders",
                newName: "IX_FireHydrantHeaders_LocationFireHydrantId");

            migrationBuilder.RenameColumn(
                name: "LocationFireHydrantId",
                table: "FireHydrantDetails",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantDetails_ItemId",
                table: "FireHydrantDetails",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHydrantDetails_Items_ItemId",
                table: "FireHydrantDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireHydrantHeaders_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantHeaders",
                column: "LocationFireHydrantId",
                principalTable: "LocationFireHydrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireHydrantDetails_Items_ItemId",
                table: "FireHydrantDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHydrantHeaders_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantHeaders");

            migrationBuilder.DropIndex(
                name: "IX_FireHydrantDetails_ItemId",
                table: "FireHydrantDetails");

            migrationBuilder.RenameColumn(
                name: "LocationFireHydrantId",
                table: "FireHydrantHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId",
                table: "FireHydrantHeaders",
                newName: "IX_FireHydrantHeaders_AreaId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "FireHydrantDetails",
                newName: "LocationFireHydrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHydrantHeaders_Areas_AreaId",
                table: "FireHydrantHeaders",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
