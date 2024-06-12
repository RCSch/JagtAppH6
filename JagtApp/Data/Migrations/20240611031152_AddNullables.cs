using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagtApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_Cartridges_AssociatedCartridgeId",
                table: "Combinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_Firearms_AssociatedFirearmId",
                table: "Combinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_GameRequirements_LegalityRequirementsId",
                table: "Combinations");

            migrationBuilder.AlterColumn<int>(
                name: "LegalityRequirementsId",
                table: "Combinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CombiName",
                table: "Combinations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AssociatedFirearmId",
                table: "Combinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AssociatedCartridgeId",
                table: "Combinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BulletDescription",
                table: "Bullets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_Cartridges_AssociatedCartridgeId",
                table: "Combinations",
                column: "AssociatedCartridgeId",
                principalTable: "Cartridges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_Firearms_AssociatedFirearmId",
                table: "Combinations",
                column: "AssociatedFirearmId",
                principalTable: "Firearms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_GameRequirements_LegalityRequirementsId",
                table: "Combinations",
                column: "LegalityRequirementsId",
                principalTable: "GameRequirements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_Cartridges_AssociatedCartridgeId",
                table: "Combinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_Firearms_AssociatedFirearmId",
                table: "Combinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Combinations_GameRequirements_LegalityRequirementsId",
                table: "Combinations");

            migrationBuilder.AlterColumn<int>(
                name: "LegalityRequirementsId",
                table: "Combinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CombiName",
                table: "Combinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssociatedFirearmId",
                table: "Combinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssociatedCartridgeId",
                table: "Combinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BulletDescription",
                table: "Bullets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_Cartridges_AssociatedCartridgeId",
                table: "Combinations",
                column: "AssociatedCartridgeId",
                principalTable: "Cartridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_Firearms_AssociatedFirearmId",
                table: "Combinations",
                column: "AssociatedFirearmId",
                principalTable: "Firearms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Combinations_GameRequirements_LegalityRequirementsId",
                table: "Combinations",
                column: "LegalityRequirementsId",
                principalTable: "GameRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
