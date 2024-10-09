using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bartender_api.Migrations
{
    /// <inheritdoc />
    public partial class tester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "makingDrink",
                table: "Configuration",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "Id",
                keyValue: 1,
                column: "makingDrink",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "makingDrink",
                table: "Configuration");
        }
    }
}
