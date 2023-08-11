using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PierresTreatsAndFlavors.Migrations
{
    public partial class FieldsToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Treats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "Flavors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "Flavors");
        }
    }
}
