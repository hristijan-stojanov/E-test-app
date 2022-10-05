using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class sedum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offered_answers_Questions_questionid",
                table: "Offered_answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offered_answers",
                table: "Offered_answers");

            migrationBuilder.RenameTable(
                name: "Offered_answers",
                newName: "Offered_Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Offered_answers_questionid",
                table: "Offered_Answers",
                newName: "IX_Offered_Answers_questionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offered_Answers",
                table: "Offered_Answers",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offered_Answers_Questions_questionid",
                table: "Offered_Answers",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offered_Answers_Questions_questionid",
                table: "Offered_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offered_Answers",
                table: "Offered_Answers");

            migrationBuilder.RenameTable(
                name: "Offered_Answers",
                newName: "Offered_answers");

            migrationBuilder.RenameIndex(
                name: "IX_Offered_Answers_questionid",
                table: "Offered_answers",
                newName: "IX_Offered_answers_questionid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offered_answers",
                table: "Offered_answers",
                column: "id");

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
