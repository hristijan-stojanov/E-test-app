using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class devettwl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTests_Test_testId",
                table: "QuestionInTests");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_AspNetUsers_userId",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameIndex(
                name: "IX_Test_userId",
                table: "Tests",
                newName: "IX_Tests_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTests_Tests_testId",
                table: "QuestionInTests",
                column: "testId",
                principalTable: "Tests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_userId",
                table: "Tests",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInTests_Tests_testId",
                table: "QuestionInTests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_userId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_userId",
                table: "Test",
                newName: "IX_Test_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInTests_Test_testId",
                table: "QuestionInTests",
                column: "testId",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_AspNetUsers_userId",
                table: "Test",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
