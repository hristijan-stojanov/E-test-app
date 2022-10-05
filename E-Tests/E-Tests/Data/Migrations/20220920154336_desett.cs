using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Tests.Data.Migrations
{
    public partial class desett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    points = table.Column<int>(nullable: false),
                    testName = table.Column<string>(nullable: true),
                    testid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.id);
                    table.ForeignKey(
                        name: "FK_Results_Tests_testid",
                        column: x => x.testid,
                        principalTable: "Tests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_testid",
                table: "Results",
                column: "testid");

            migrationBuilder.CreateIndex(
                name: "IX_Results_userId",
                table: "Results",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
