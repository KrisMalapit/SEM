using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Bicycles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_DepartmentID",
                table: "Bicycles",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_Departments_DepartmentID",
                table: "Bicycles",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_Departments_DepartmentID",
                table: "Bicycles");

            migrationBuilder.DropIndex(
                name: "IX_Bicycles_DepartmentID",
                table: "Bicycles");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Bicycles");
        }
    }
}
