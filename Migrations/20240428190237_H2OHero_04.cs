using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRMS.Migrations
{
    /// <inheritdoc />
    public partial class H2OHero_04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CultvoId",
                table: "Granja");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CultvoId",
                table: "Granja",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
