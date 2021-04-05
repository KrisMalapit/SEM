using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocationFireExtinguishers_AreaId",
                table: "LocationFireExtinguishers");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LocationFireExtinguishers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LocationFireExtinguishers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LocationEmergencyLights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    AreaId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEmergencyLights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationEmergencyLights_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguishers_AreaId_Code_Status",
                table: "LocationFireExtinguishers",
                columns: new[] { "AreaId", "Code", "Status" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [Status] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocationEmergencyLights_AreaId_Code_Status",
                table: "LocationEmergencyLights",
                columns: new[] { "AreaId", "Code", "Status" },
                unique: true,
                filter: "[Code] IS NOT NULL AND [Status] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationEmergencyLights");

            migrationBuilder.DropIndex(
                name: "IX_LocationFireExtinguishers_AreaId_Code_Status",
                table: "LocationFireExtinguishers");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LocationFireExtinguishers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LocationFireExtinguishers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguishers_AreaId",
                table: "LocationFireExtinguishers",
                column: "AreaId");
        }
    }
}
