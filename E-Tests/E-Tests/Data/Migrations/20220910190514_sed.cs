using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class sed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correct_answer",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "correctAnswer",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "correctAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "correct_answer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
