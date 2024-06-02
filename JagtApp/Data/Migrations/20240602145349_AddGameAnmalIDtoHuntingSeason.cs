using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagtApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGameAnmalIDtoHuntingSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HuntingSeasons_GameAnimals_GameAnimalId",
                table: "HuntingSeasons");

            migrationBuilder.AlterColumn<int>(
                name: "GameAnimalId",
                table: "HuntingSeasons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HuntingSeasons_GameAnimals_GameAnimalId",
                table: "HuntingSeasons",
                column: "GameAnimalId",
                principalTable: "GameAnimals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HuntingSeasons_GameAnimals_GameAnimalId",
                table: "HuntingSeasons");

            migrationBuilder.AlterColumn<int>(
                name: "GameAnimalId",
                table: "HuntingSeasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HuntingSeasons_GameAnimals_GameAnimalId",
                table: "HuntingSeasons",
                column: "GameAnimalId",
                principalTable: "GameAnimals",
                principalColumn: "Id");
        }
    }
}
