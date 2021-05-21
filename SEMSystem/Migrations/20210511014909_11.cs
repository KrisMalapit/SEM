using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocationItemDetails_ItemId",
                table: "LocationItemDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LocationItemDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationItemDetails_ItemId_Status",
                table: "LocationItemDetails",
                columns: new[] { "ItemId", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocationItemDetails_ItemId_Status",
                table: "LocationItemDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LocationItemDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationItemDetails_ItemId",
                table: "LocationItemDetails",
                column: "ItemId");
        }
    }
}
