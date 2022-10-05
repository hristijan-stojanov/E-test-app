using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class treta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.AddColumn<Guid>(
                name: "questionid",
                table: "Offered_answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offered_answers_questionid",
                table: "Offered_answers",
                column: "questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offered_answers_Questions_questionid",
                table: "Offered_answers",
                column: "questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offered_answers_Questions_questionid",
                table: "Offered_answers");

            migrationBuilder.DropIndex(
                name: "IX_Offered_answers_questionid",
                table: "Offered_answers");

            migrationBuilder.DropColumn(
                name: "questionid",
                table: "Offered_answers");

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    questionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    answersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => new { x.questionId, x.answersId });
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Questions_answersId",
                        column: x => x.answersId,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Offered_answers_questionId",
                        column: x => x.questionId,
                        principalTable: "Offered_answers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_answersId",
                table: "QuestionAnswer",
                column: "answersId");
        }
    }
}
