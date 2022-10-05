using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class cetvrta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offered_answers_Questions_questionid",
                table: "Offered_answers");

            migrationBuilder.RenameColumn(
                name: "questionid",
                table: "Offered_answers",
                newName: "Questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Offered_answers_questionid",
                table: "Offered_answers",
                newName: "IX_Offered_answers_Questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offered_answers_Questions_Questionid",
                table: "Offered_answers",
                column: "Questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offered_answers_Questions_Questionid",
                table: "Offered_answers");

            migrationBuilder.RenameColumn(
                name: "Questionid",
                table: "Offered_answers",
                newName: "questionid");

            migrationBuilder.RenameIndex(
                name: "IX_Offered_answers_Questionid",
                table: "Offered_answers",
                newName: "IX_Offered_answers_questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offered_answers_Questions_questionid",
                table: "Offered_answers",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
