using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "DatePurchased",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.RenameColumn(
                name: "Warranty",
                table: "LocationFireExtinguisherDetails",
                newName: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_ItemId",
                table: "LocationFireExtinguisherDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFireExtinguisherDetails_Items_ItemId",
                table: "LocationFireExtinguisherDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherId",
                principalTable: "LocationFireExtinguishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationFireExtinguisherDetails_Items_ItemId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguishers_LocationFireExtinguisherId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropIndex(
                name: "IX_LocationFireExtinguisherDetails_ItemId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.DropIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherId",
                table: "LocationFireExtinguisherDetails");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "LocationFireExtinguisherDetails",
                newName: "Warranty");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePurchased",
                table: "LocationFireExtinguisherDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ItemStatus",
                table: "LocationFireExtinguisherDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "LocationFireExtinguisherDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationFireExtinguisherDetails_LocationFireExtinguisherDetails_LocationFireExtinguisherDetailsId",
                table: "LocationFireExtinguisherDetails",
                column: "LocationFireExtinguisherDetailsId",
                principalTable: "LocationFireExtinguisherDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
