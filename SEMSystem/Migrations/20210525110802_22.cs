using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLogs_Items_ItemId",
                table: "ItemLogs");

            migrationBuilder.DropIndex(
                name: "IX_ItemLogs_ItemId",
                table: "ItemLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemLogs_ItemId",
                table: "ItemLogs",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLogs_Items_ItemId",
                table: "ItemLogs",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
