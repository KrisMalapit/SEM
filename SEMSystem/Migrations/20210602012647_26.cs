using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SEMSystem.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "InergenTankHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedDate",
                table: "InergenTankHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "FireHydrantHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedDate",
                table: "FireHydrantHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "FireExtinguisherHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedDate",
                table: "FireExtinguisherHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "EmergencyLightHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedDate",
                table: "EmergencyLightHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "InergenTankHeaders");

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "InergenTankHeaders");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "FireHydrantHeaders");

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "FireHydrantHeaders");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "FireExtinguisherHeaders");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "EmergencyLightHeaders");

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "EmergencyLightHeaders");
        }
    }
}
