using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class devettw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTest_Questions_questionId",
                table: "QuestionInTest");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTest_Test_testId",
                table: "QuestionInTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionInTest",
                table: "QuestionInTest");

            migrationBuilder.RenameTable(
                name: "QuestionInTest",
                newName: "QuestionInTests");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionInTest_testId",
                table: "QuestionInTests",
                newName: "IX_QuestionInTests_testId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionInTests",
                table: "QuestionInTests",
                columns: new[] { "questionId", "testId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTests_Questions_questionId",
                table: "QuestionInTests",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTests_Test_testId",
                table: "QuestionInTests",
                column: "testId",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTests_Questions_questionId",
                table: "QuestionInTests");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTests_Test_testId",
                table: "QuestionInTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionInTests",
                table: "QuestionInTests");

            migrationBuilder.RenameTable(
                name: "QuestionInTests",
                newName: "QuestionInTest");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionInTests_testId",
                table: "QuestionInTest",
                newName: "IX_QuestionInTest_testId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionInTest",
                table: "QuestionInTest",
                columns: new[] { "questionId", "testId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTest_Questions_questionId",
                table: "QuestionInTest",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTest_Test_testId",
                table: "QuestionInTest",
                column: "testId",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
