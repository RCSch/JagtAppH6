using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagtApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHuntingSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "HuntingSeasons");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "HuntingSeasons");

            migrationBuilder.AddColumn<int>(
                name: "EndDay",
                table: "HuntingSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndMonth",
                table: "HuntingSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartDay",
                table: "HuntingSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMonth",
                table: "HuntingSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDay",
                table: "HuntingSeasons");

            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "HuntingSeasons");

            migrationBuilder.DropColumn(
                name: "StartDay",
                table: "HuntingSeasons");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "HuntingSeasons");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "HuntingSeasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "HuntingSeasons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
