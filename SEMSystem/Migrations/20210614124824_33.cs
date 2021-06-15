using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireHydrantHeaders_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantHeaders");

            migrationBuilder.RenameColumn(
                name: "LocationFireHydrantId",
                table: "FireHydrantHeaders",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_FireHydrantHeaders_LocationFireHydrantId_CreatedAt_Status",
                table: "FireHydrantHeaders",
                newName: "IX_FireHydrantHeaders_AreaId_CreatedAt_Status");

            migrationBuilder.AddColumn<int>(
                name: "LocationFireHydrantId",
                table: "FireHydrantDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FireHydrantDetails_LocationFireHydrantId",
                table: "FireHydrantDetails",
                column: "LocationFireHydrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHydrantDetails_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantDetails",
                column: "LocationFireHydrantId",
                principalTable: "LocationFireHydrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireHydrantDetails_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantDetails");

            migrationBuilder.DropIndex(
                name: "IX_FireHydrantDetails_LocationFireHydrantId",
                table: "FireHydrantDetails");

            migrationBuilder.DropColumn(
                name: "LocationFireHydrantId",
                table: "FireHydrantDetails");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "FireHydrantHeaders",
                newName: "LocationFireHydrantId");

            migrationBuilder.RenameIndex(
                name: "IX_FireHydrantHeaders_AreaId_CreatedAt_Status",
                table: "FireHydrantHeaders",
                newName: "IX_FireHydrantHeaders_LocationFireHydrantId_CreatedAt_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHydrantHeaders_LocationFireHydrants_LocationFireHydrantId",
                table: "FireHydrantHeaders",
                column: "LocationFireHydrantId",
                principalTable: "LocationFireHydrants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
