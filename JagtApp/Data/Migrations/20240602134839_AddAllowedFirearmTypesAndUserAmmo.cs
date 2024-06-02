using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JagtApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAllowedFirearmTypesAndUserAmmo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllowedFirearmTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameRequirementId = table.Column<int>(type: "int", nullable: false),
                    FirearmType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedFirearmTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowedFirearmTypes_GameRequirements_GameRequirementId",
                        column: x => x.GameRequirementId,
                        principalTable: "GameRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAmmunitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartridgeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAmmunitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAmmunitions_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAmmunitions_Cartridges_CartridgeId",
                        column: x => x.CartridgeId,
                        principalTable: "Cartridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedFirearmTypes_GameRequirementId",
                table: "AllowedFirearmTypes",
                column: "GameRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAmmunitions_CartridgeId",
                table: "UserAmmunitions",
                column: "CartridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAmmunitions_OwnerId",
                table: "UserAmmunitions",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedFirearmTypes");

            migrationBuilder.DropTable(
                name: "UserAmmunitions");
        }
    }
}
