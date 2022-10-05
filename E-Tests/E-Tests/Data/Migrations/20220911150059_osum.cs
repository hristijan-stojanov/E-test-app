using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class osum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.id);
                    table.ForeignKey(
                        name: "FK_Test_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionInTest",
                columns: table => new
                {
                    questionId = table.Column<Guid>(nullable: false),
                    testId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionInTest", x => new { x.questionId, x.testId });
                    table.ForeignKey(
                        name: "FK_QuestionInTest_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionInTest_Test_testId",
                        column: x => x.testId,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionInTest_testId",
                table: "QuestionInTest",
                column: "testId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_userId",
                table: "Test",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionInTest");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropColumn(
                name: "FastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");
        }
    }
}
