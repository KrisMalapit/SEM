using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireExtinguisherHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "FireExtinguisherHeaders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguisherHeaders_AreaId_CreatedAt_Status",
                table: "FireExtinguisherHeaders",
                columns: new[] { "AreaId", "CreatedAt", "Status" },
                unique: true,
                filter: "[Status] IS NOT NULL");
        }
    }
}
