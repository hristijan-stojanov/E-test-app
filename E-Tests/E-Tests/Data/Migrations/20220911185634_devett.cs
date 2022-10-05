using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class devett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Test",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "time",
                table: "Test",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "points",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "points",
                table: "Questions");
        }
    }
}
