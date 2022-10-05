using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class devet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offered_Answers");

            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer3",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer4",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer3",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer4",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "Offered_Answers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offered_Answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offered_Answers_Questions_questionid",
                        column: x => x.questionid,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offered_Answers_questionid",
                table: "Offered_Answers",
                column: "questionid");
        }
    }
}
