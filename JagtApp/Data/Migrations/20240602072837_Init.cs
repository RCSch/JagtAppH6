using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagtApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmmunitionRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumCaliber = table.Column<double>(type: "float", nullable: false),
                    MinimumE100 = table.Column<double>(type: "float", nullable: false),
                    MinimumE0 = table.Column<double>(type: "float", nullable: false),
                    MinimumV0 = table.Column<double>(type: "float", nullable: false),
                    RequiresExpandingProjectile = table.Column<bool>(type: "bit", nullable: false),
                    LeadFree = table.Column<bool>(type: "bit", nullable: false),
                    MinShotSize = table.Column<int>(type: "int", nullable: false),
                    MaxShotSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmunitionRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bullets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulletName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BulletDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BulletWeight = table.Column<double>(type: "float", nullable: false),
                    BulletDiameter = table.Column<double>(type: "float", nullable: false),
                    LeadFree = table.Column<bool>(type: "bit", nullable: false),
                    Expanding = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bullets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firearms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LicenceExpirationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firearms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firearms_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAnimals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequiredClass = table.Column<int>(type: "int", nullable: false),
                    AmmoRequirementsId = table.Column<int>(type: "int", nullable: false),
                    MaxShotgunRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRequirements_AmmunitionRequirements_AmmoRequirementsId",
                        column: x => x.AmmoRequirementsId,
                        principalTable: "AmmunitionRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calibers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaliberName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CaliberDiameter = table.Column<double>(type: "float", nullable: false),
                    FirearmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calibers_Firearms_FirearmId",
                        column: x => x.FirearmId,
                        principalTable: "Firearms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HuntingSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameAnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuntingSeasons_GameAnimals_GameAnimalId",
                        column: x => x.GameAnimalId,
                        principalTable: "GameAnimals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartridges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulletId = table.Column<int>(type: "int", nullable: false),
                    CaliberId = table.Column<int>(type: "int", nullable: false),
                    CartridgeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartridges_Bullets_BulletId",
                        column: x => x.BulletId,
                        principalTable: "Bullets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cartridges_Calibers_CaliberId",
                        column: x => x.CaliberId,
                        principalTable: "Calibers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Combinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CombiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LegalityRequirementsId = table.Column<int>(type: "int", nullable: false),
                    IsLegal = table.Column<bool>(type: "bit", nullable: false),
                    V0 = table.Column<double>(type: "float", nullable: false),
                    E0 = table.Column<double>(type: "float", nullable: false),
                    AssociatedCartridgeId = table.Column<int>(type: "int", nullable: false),
                    V100 = table.Column<double>(type: "float", nullable: false),
                    E100 = table.Column<double>(type: "float", nullable: false),
                    GameClass = table.Column<int>(type: "int", nullable: false),
                    AssociatedFirearmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combinations_Cartridges_AssociatedCartridgeId",
                        column: x => x.AssociatedCartridgeId,
                        principalTable: "Cartridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combinations_Firearms_AssociatedFirearmId",
                        column: x => x.AssociatedFirearmId,
                        principalTable: "Firearms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combinations_GameRequirements_LegalityRequirementsId",
                        column: x => x.LegalityRequirementsId,
                        principalTable: "GameRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calibers_FirearmId",
                table: "Calibers",
                column: "FirearmId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_BulletId",
                table: "Cartridges",
                column: "BulletId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartridges_CaliberId",
                table: "Cartridges",
                column: "CaliberId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_AssociatedCartridgeId",
                table: "Combinations",
                column: "AssociatedCartridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_AssociatedFirearmId",
                table: "Combinations",
                column: "AssociatedFirearmId");

            migrationBuilder.CreateIndex(
                name: "IX_Combinations_LegalityRequirementsId",
                table: "Combinations",
                column: "LegalityRequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Firearms_OwnerId",
                table: "Firearms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRequirements_AmmoRequirementsId",
                table: "GameRequirements",
                column: "AmmoRequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_HuntingSeasons_GameAnimalId",
                table: "HuntingSeasons",
                column: "GameAnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combinations");

            migrationBuilder.DropTable(
                name: "HuntingSeasons");

            migrationBuilder.DropTable(
                name: "Cartridges");

            migrationBuilder.DropTable(
                name: "GameRequirements");

            migrationBuilder.DropTable(
                name: "GameAnimals");

            migrationBuilder.DropTable(
                name: "Bullets");

            migrationBuilder.DropTable(
                name: "Calibers");

            migrationBuilder.DropTable(
                name: "AmmunitionRequirements");

            migrationBuilder.DropTable(
                name: "Firearms");
        }
    }
}
