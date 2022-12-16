using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDate = table.Column<DateTime>(type: "date", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentUniTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    IsPresent = table.Column<bool>(type: "bit", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    UniTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUniTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUniTasks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentUniTasks_UniTasks_UniTaskId",
                        column: x => x.UniTaskId,
                        principalTable: "UniTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Oleg", "Sencov" },
                    { 2, "John", "Travolta" },
                    { 3, "Johnathan", "Joestar" }
                });

            migrationBuilder.InsertData(
                table: "UniTasks",
                columns: new[] { "Id", "Description", "Priority", "Status", "TaskDate" },
                values: new object[,]
                {
                    { 1, "Lab1", "Mid", null, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Lab2", "Mid", null, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "KR", "High", null, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "StudentUniTasks",
                columns: new[] { "Id", "Grade", "IsPresent", "StudentId", "UniTaskId" },
                values: new object[,]
                {
                    { 1, 5, true, 1, 1 },
                    { 2, 0, false, 1, 2 },
                    { 3, 5, true, 1, 3 },
                    { 4, 3, true, 2, 1 },
                    { 5, 4, true, 2, 2 },
                    { 6, 5, true, 2, 3 },
                    { 7, 0, false, 3, 1 },
                    { 8, 4, true, 3, 2 },
                    { 9, 3, true, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentUniTasks_StudentId",
                table: "StudentUniTasks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUniTasks_UniTaskId",
                table: "StudentUniTasks",
                column: "UniTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentUniTasks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UniTasks");
        }
    }
}
