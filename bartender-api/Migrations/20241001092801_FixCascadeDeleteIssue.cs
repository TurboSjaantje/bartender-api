using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bartender_api.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MocktailCombinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MocktailCombinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drink1Id = table.Column<int>(type: "int", nullable: false),
                    Drink2Id = table.Column<int>(type: "int", nullable: false),
                    Drink3Id = table.Column<int>(type: "int", nullable: false),
                    Drink4Id = table.Column<int>(type: "int", nullable: false),
                    Drink5Id = table.Column<int>(type: "int", nullable: false),
                    Drink6Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DrinkWithPercentages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    MocktailCombinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkWithPercentages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkWithPercentages_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkWithPercentages_MocktailCombinations_MocktailCombinationId",
                        column: x => x.MocktailCombinationId,
                        principalTable: "MocktailCombinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Name", "Volume" },
                values: new object[,]
                {
                    { 1, "Appelsap", 250f },
                    { 2, "Sprite / 7Up", 200f },
                    { 3, "Sinaasappelsap", 250f },
                    { 4, "Cola", 330f },
                    { 5, "Fanta", 250f },
                    { 6, "Bruisend water", 500f },
                    { 7, "Ice tea perzik", 330f },
                    { 8, "Ginger ale", 200f }
                });

            migrationBuilder.InsertData(
                table: "MocktailCombinations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Crisp Fizz" },
                    { 2, "Citrus Cola" },
                    { 3, "Fruity Splash" },
                    { 4, "Peach Fizz" },
                    { 5, "Apple Fizz" },
                    { 6, "Tropical Fizz" },
                    { 7, "Citrus Delight" },
                    { 8, "Refreshing Berry" },
                    { 9, "Apple Citrus Sparkle" },
                    { 10, "Cola Fanta Mix" },
                    { 11, "Citrus Berry Splash" },
                    { 12, "Sparkling Citrus Punch" },
                    { 13, "Apple Fanta Delight" },
                    { 14, "Fruity Ginger Mix" },
                    { 15, "Tropical Twist" },
                    { 16, "Crisp Refreshment" },
                    { 17, "Citrus Punch" },
                    { 18, "Fruity Delight" },
                    { 19, "Sparkling Fruit Medley" },
                    { 20, "Citrus Melange" }
                });

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "Id", "Drink1Id", "Drink2Id", "Drink3Id", "Drink4Id", "Drink5Id", "Drink6Id" },
                values: new object[] { 1, 1, 2, 3, 4, 5, 6 });

            migrationBuilder.InsertData(
                table: "DrinkWithPercentages",
                columns: new[] { "Id", "DrinkId", "MocktailCombinationId", "Percentage" },
                values: new object[,]
                {
                    { 1, 1, 1, 60f },
                    { 2, 2, 1, 40f },
                    { 3, 3, 2, 50f },
                    { 4, 4, 2, 50f },
                    { 5, 5, 3, 70f },
                    { 6, 6, 3, 30f },
                    { 7, 7, 4, 60f },
                    { 8, 8, 4, 40f },
                    { 9, 1, 5, 50f },
                    { 10, 6, 5, 50f },
                    { 11, 5, 6, 40f },
                    { 12, 1, 6, 30f },
                    { 13, 2, 6, 30f },
                    { 14, 3, 7, 40f },
                    { 15, 8, 7, 30f },
                    { 16, 6, 7, 30f },
                    { 17, 7, 8, 40f },
                    { 18, 4, 8, 30f },
                    { 19, 2, 8, 30f },
                    { 20, 1, 9, 40f },
                    { 21, 3, 9, 30f },
                    { 22, 8, 9, 30f },
                    { 23, 4, 10, 50f },
                    { 24, 5, 10, 50f },
                    { 25, 6, 10, 20f },
                    { 26, 3, 11, 30f },
                    { 27, 1, 11, 30f },
                    { 28, 7, 11, 20f },
                    { 29, 2, 11, 20f },
                    { 30, 2, 12, 30f },
                    { 31, 8, 12, 30f },
                    { 32, 5, 12, 20f },
                    { 33, 6, 12, 20f },
                    { 34, 1, 13, 30f },
                    { 35, 5, 13, 30f },
                    { 36, 4, 13, 20f },
                    { 37, 6, 13, 20f },
                    { 38, 8, 14, 40f },
                    { 39, 7, 14, 30f },
                    { 40, 1, 14, 20f },
                    { 41, 2, 14, 10f },
                    { 42, 5, 15, 30f },
                    { 43, 7, 15, 30f },
                    { 44, 4, 15, 20f },
                    { 45, 6, 15, 20f },
                    { 46, 2, 16, 25f },
                    { 47, 1, 16, 25f },
                    { 48, 5, 16, 20f },
                    { 49, 8, 16, 20f },
                    { 50, 6, 16, 10f },
                    { 51, 3, 17, 25f },
                    { 52, 1, 17, 25f },
                    { 53, 7, 17, 20f },
                    { 54, 4, 17, 20f },
                    { 55, 8, 17, 10f },
                    { 56, 5, 18, 25f },
                    { 57, 2, 18, 25f },
                    { 58, 7, 18, 20f },
                    { 59, 1, 18, 20f },
                    { 60, 6, 18, 10f },
                    { 61, 2, 19, 20f },
                    { 62, 5, 19, 20f },
                    { 63, 4, 19, 20f },
                    { 64, 1, 19, 20f },
                    { 65, 8, 19, 10f },
                    { 66, 7, 19, 10f },
                    { 67, 3, 20, 20f },
                    { 68, 1, 20, 20f },
                    { 69, 2, 20, 20f },
                    { 70, 5, 20, 20f },
                    { 71, 8, 20, 10f },
                    { 72, 6, 20, 10f }
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

            migrationBuilder.CreateIndex(
                name: "IX_DrinkWithPercentages_DrinkId",
                table: "DrinkWithPercentages",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkWithPercentages_MocktailCombinationId",
                table: "DrinkWithPercentages",
                column: "MocktailCombinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "DrinkWithPercentages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "MocktailCombinations");
        }
    }
}
