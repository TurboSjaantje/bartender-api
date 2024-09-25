using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bartender_api.Migrations
{
    /// <inheritdoc />
    public partial class init_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drink1Id = table.Column<int>(type: "int", nullable: true),
                    Drink2Id = table.Column<int>(type: "int", nullable: true),
                    Drink3Id = table.Column<int>(type: "int", nullable: true),
                    Drink4Id = table.Column<int>(type: "int", nullable: true),
                    Drink5Id = table.Column<int>(type: "int", nullable: true),
                    Drink6Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink1Id",
                        column: x => x.Drink1Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink2Id",
                        column: x => x.Drink2Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink3Id",
                        column: x => x.Drink3Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink4Id",
                        column: x => x.Drink4Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink5Id",
                        column: x => x.Drink5Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Configuration_Drinks_Drink6Id",
                        column: x => x.Drink6Id,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink1Id",
                table: "Configuration",
                column: "Drink1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink2Id",
                table: "Configuration",
                column: "Drink2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink3Id",
                table: "Configuration",
                column: "Drink3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink4Id",
                table: "Configuration",
                column: "Drink4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink5Id",
                table: "Configuration",
                column: "Drink5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Drink6Id",
                table: "Configuration",
                column: "Drink6Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");
        }
    }
}
