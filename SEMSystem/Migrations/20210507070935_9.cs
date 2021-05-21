using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationFireExtinguisherDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationFireExtinguisherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    LocationFireExtinguisherId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFireExtinguisherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationFireExtinguisherDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguishers_LocationFireExtinguisherId",
                        column: x => x.LocationFireExtinguisherId,
                        principalTable: "LocationFireExtinguishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_ItemId",
                table: "LocationFireExtinguisherDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherId");
        }
    }
}
