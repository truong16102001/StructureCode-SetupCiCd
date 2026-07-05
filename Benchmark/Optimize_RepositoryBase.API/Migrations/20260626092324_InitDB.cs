using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Optimize_RepositoryBase.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsRegularStudent = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    AdditionalExplanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluations_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentDetailsId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 19, "Student 1" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), 20, true, "Student 2" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), 21, "Student 3" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), 22, true, "Student 4" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), 23, "Student 5" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), 24, true, "Student 6" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000007"), 25, "Student 7" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), 26, true, "Student 8" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), 27, "Student 9" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000010"), 28, true, "Student 10" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), 29, "Student 11" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), 30, true, "Student 12" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), 31, "Student 13" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000014"), 32, true, "Student 14" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), 33, "Student 15" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000016"), 34, true, "Student 16" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000017"), 35, "Student 17" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000018"), 36, true, "Student 18" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000019"), 37, "Student 19" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000020"), 38, true, "Student 20" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000021"), 39, "Student 21" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000022"), 40, true, "Student 22" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000023"), 41, "Student 23" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000024"), 42, true, "Student 24" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000025"), 43, "Student 25" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000026"), 44, true, "Student 26" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000027"), 45, "Student 27" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000028"), 46, true, "Student 28" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000029"), 47, "Student 29" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000030"), 48, true, "Student 30" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000031"), 49, "Student 31" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000032"), 50, true, "Student 32" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000033"), 51, "Student 33" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000034"), 52, true, "Student 34" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000035"), 53, "Student 35" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000036"), 54, true, "Student 36" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000037"), 55, "Student 37" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000038"), 56, true, "Student 38" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000039"), 57, "Student 39" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000040"), 18, true, "Student 40" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000041"), 19, "Student 41" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000042"), 20, true, "Student 42" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000043"), 21, "Student 43" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000044"), 22, true, "Student 44" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), 23, "Student 45" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000046"), 24, true, "Student 46" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000047"), 25, "Student 47" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000048"), 26, true, "Student 48" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000049"), 27, "Student 49" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000050"), 28, true, "Student 50" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000051"), 29, "Student 51" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000052"), 30, true, "Student 52" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000053"), 31, "Student 53" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000054"), 32, true, "Student 54" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000055"), 33, "Student 55" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000056"), 34, true, "Student 56" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000057"), 35, "Student 57" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000058"), 36, true, "Student 58" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000059"), 37, "Student 59" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000060"), 38, true, "Student 60" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000061"), 39, "Student 61" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000062"), 40, true, "Student 62" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000063"), 41, "Student 63" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000064"), 42, true, "Student 64" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000065"), 43, "Student 65" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000066"), 44, true, "Student 66" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000067"), 45, "Student 67" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000068"), 46, true, "Student 68" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000069"), 47, "Student 69" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000070"), 48, true, "Student 70" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000071"), 49, "Student 71" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000072"), 50, true, "Student 72" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000073"), 51, "Student 73" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000074"), 52, true, "Student 74" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000075"), 53, "Student 75" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000076"), 54, true, "Student 76" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000077"), 55, "Student 77" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000078"), 56, true, "Student 78" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000079"), 57, "Student 79" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000080"), 18, true, "Student 80" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000081"), 19, "Student 81" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000082"), 20, true, "Student 82" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000083"), 21, "Student 83" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000084"), 22, true, "Student 84" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000085"), 23, "Student 85" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000086"), 24, true, "Student 86" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000087"), 25, "Student 87" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000088"), 26, true, "Student 88" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000089"), 27, "Student 89" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000090"), 28, true, "Student 90" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000091"), 29, "Student 91" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000092"), 30, true, "Student 92" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000093"), 31, "Student 93" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000094"), 32, true, "Student 94" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000095"), 33, "Student 95" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000096"), 34, true, "Student 96" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000097"), 35, "Student 97" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000098"), 36, true, "Student 98" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000099"), 37, "Student 99" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000100"), 38, true, "Student 100" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000101"), 39, "Student 101" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000102"), 40, true, "Student 102" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000103"), 41, "Student 103" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000104"), 42, true, "Student 104" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000105"), 43, "Student 105" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000106"), 44, true, "Student 106" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000107"), 45, "Student 107" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000108"), 46, true, "Student 108" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000109"), 47, "Student 109" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000110"), 48, true, "Student 110" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000111"), 49, "Student 111" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000112"), 50, true, "Student 112" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000113"), 51, "Student 113" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000114"), 52, true, "Student 114" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000115"), 53, "Student 115" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000116"), 54, true, "Student 116" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000117"), 55, "Student 117" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000118"), 56, true, "Student 118" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000119"), 57, "Student 119" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000120"), 18, true, "Student 120" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000121"), 19, "Student 121" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000122"), 20, true, "Student 122" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000123"), 21, "Student 123" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000124"), 22, true, "Student 124" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000125"), 23, "Student 125" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000126"), 24, true, "Student 126" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000127"), 25, "Student 127" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000128"), 26, true, "Student 128" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000129"), 27, "Student 129" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000130"), 28, true, "Student 130" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000131"), 29, "Student 131" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000132"), 30, true, "Student 132" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000133"), 31, "Student 133" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000134"), 32, true, "Student 134" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000135"), 33, "Student 135" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000136"), 34, true, "Student 136" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000137"), 35, "Student 137" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000138"), 36, true, "Student 138" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000139"), 37, "Student 139" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000140"), 38, true, "Student 140" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000141"), 39, "Student 141" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000142"), 40, true, "Student 142" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000143"), 41, "Student 143" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000144"), 42, true, "Student 144" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000145"), 43, "Student 145" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000146"), 44, true, "Student 146" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000147"), 45, "Student 147" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000148"), 46, true, "Student 148" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000149"), 47, "Student 149" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000150"), 48, true, "Student 150" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000151"), 49, "Student 151" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000152"), 50, true, "Student 152" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000153"), 51, "Student 153" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000154"), 52, true, "Student 154" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000155"), 53, "Student 155" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000156"), 54, true, "Student 156" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000157"), 55, "Student 157" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000158"), 56, true, "Student 158" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000159"), 57, "Student 159" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000160"), 18, true, "Student 160" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000161"), 19, "Student 161" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000162"), 20, true, "Student 162" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000163"), 21, "Student 163" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000164"), 22, true, "Student 164" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000165"), 23, "Student 165" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000166"), 24, true, "Student 166" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000167"), 25, "Student 167" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000168"), 26, true, "Student 168" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000169"), 27, "Student 169" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000170"), 28, true, "Student 170" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000171"), 29, "Student 171" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000172"), 30, true, "Student 172" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000173"), 31, "Student 173" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000174"), 32, true, "Student 174" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000175"), 33, "Student 175" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000176"), 34, true, "Student 176" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000177"), 35, "Student 177" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000178"), 36, true, "Student 178" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000179"), 37, "Student 179" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000180"), 38, true, "Student 180" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000181"), 39, "Student 181" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000182"), 40, true, "Student 182" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000183"), 41, "Student 183" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000184"), 42, true, "Student 184" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000185"), 43, "Student 185" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000186"), 44, true, "Student 186" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000187"), 45, "Student 187" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000188"), 46, true, "Student 188" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000189"), 47, "Student 189" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000190"), 48, true, "Student 190" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000191"), 49, "Student 191" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000192"), 50, true, "Student 192" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000193"), 51, "Student 193" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000194"), 52, true, "Student 194" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000195"), 53, "Student 195" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000196"), 54, true, "Student 196" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000197"), 55, "Student 197" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000198"), 56, true, "Student 198" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000199"), 57, "Student 199" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000200"), 18, true, "Student 200" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000201"), 19, "Student 201" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000202"), 20, true, "Student 202" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000203"), 21, "Student 203" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000204"), 22, true, "Student 204" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000205"), 23, "Student 205" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000206"), 24, true, "Student 206" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000207"), 25, "Student 207" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000208"), 26, true, "Student 208" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000209"), 27, "Student 209" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000210"), 28, true, "Student 210" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000211"), 29, "Student 211" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000212"), 30, true, "Student 212" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000213"), 31, "Student 213" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000214"), 32, true, "Student 214" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000215"), 33, "Student 215" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000216"), 34, true, "Student 216" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000217"), 35, "Student 217" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000218"), 36, true, "Student 218" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000219"), 37, "Student 219" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000220"), 38, true, "Student 220" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000221"), 39, "Student 221" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000222"), 40, true, "Student 222" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000223"), 41, "Student 223" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000224"), 42, true, "Student 224" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000225"), 43, "Student 225" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000226"), 44, true, "Student 226" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000227"), 45, "Student 227" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000228"), 46, true, "Student 228" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000229"), 47, "Student 229" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000230"), 48, true, "Student 230" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000231"), 49, "Student 231" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000232"), 50, true, "Student 232" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000233"), 51, "Student 233" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000234"), 52, true, "Student 234" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000235"), 53, "Student 235" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000236"), 54, true, "Student 236" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000237"), 55, "Student 237" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000238"), 56, true, "Student 238" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000239"), 57, "Student 239" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000240"), 18, true, "Student 240" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000241"), 19, "Student 241" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000242"), 20, true, "Student 242" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000243"), 21, "Student 243" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000244"), 22, true, "Student 244" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000245"), 23, "Student 245" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000246"), 24, true, "Student 246" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000247"), 25, "Student 247" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000248"), 26, true, "Student 248" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000249"), 27, "Student 249" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000250"), 28, true, "Student 250" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000251"), 29, "Student 251" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000252"), 30, true, "Student 252" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000253"), 31, "Student 253" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000254"), 32, true, "Student 254" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000255"), 33, "Student 255" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000256"), 34, true, "Student 256" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000257"), 35, "Student 257" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000258"), 36, true, "Student 258" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000259"), 37, "Student 259" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000260"), 38, true, "Student 260" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000261"), 39, "Student 261" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000262"), 40, true, "Student 262" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000263"), 41, "Student 263" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000264"), 42, true, "Student 264" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000265"), 43, "Student 265" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000266"), 44, true, "Student 266" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000267"), 45, "Student 267" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000268"), 46, true, "Student 268" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000269"), 47, "Student 269" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000270"), 48, true, "Student 270" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000271"), 49, "Student 271" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000272"), 50, true, "Student 272" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000273"), 51, "Student 273" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000274"), 52, true, "Student 274" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000275"), 53, "Student 275" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000276"), 54, true, "Student 276" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000277"), 55, "Student 277" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000278"), 56, true, "Student 278" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000279"), 57, "Student 279" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000280"), 18, true, "Student 280" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000281"), 19, "Student 281" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000282"), 20, true, "Student 282" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000283"), 21, "Student 283" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000284"), 22, true, "Student 284" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000285"), 23, "Student 285" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000286"), 24, true, "Student 286" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000287"), 25, "Student 287" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000288"), 26, true, "Student 288" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000289"), 27, "Student 289" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000290"), 28, true, "Student 290" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000291"), 29, "Student 291" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000292"), 30, true, "Student 292" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000293"), 31, "Student 293" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000294"), 32, true, "Student 294" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000295"), 33, "Student 295" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000296"), 34, true, "Student 296" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000297"), 35, "Student 297" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000298"), 36, true, "Student 298" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000299"), 37, "Student 299" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000300"), 38, true, "Student 300" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000301"), 39, "Student 301" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000302"), 40, true, "Student 302" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000303"), 41, "Student 303" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000304"), 42, true, "Student 304" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000305"), 43, "Student 305" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000306"), 44, true, "Student 306" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000307"), 45, "Student 307" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000308"), 46, true, "Student 308" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000309"), 47, "Student 309" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000310"), 48, true, "Student 310" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000311"), 49, "Student 311" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000312"), 50, true, "Student 312" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000313"), 51, "Student 313" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000314"), 52, true, "Student 314" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000315"), 53, "Student 315" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000316"), 54, true, "Student 316" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000317"), 55, "Student 317" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000318"), 56, true, "Student 318" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000319"), 57, "Student 319" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000320"), 18, true, "Student 320" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000321"), 19, "Student 321" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000322"), 20, true, "Student 322" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000323"), 21, "Student 323" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000324"), 22, true, "Student 324" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000325"), 23, "Student 325" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000326"), 24, true, "Student 326" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000327"), 25, "Student 327" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000328"), 26, true, "Student 328" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000329"), 27, "Student 329" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000330"), 28, true, "Student 330" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000331"), 29, "Student 331" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000332"), 30, true, "Student 332" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000333"), 31, "Student 333" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000334"), 32, true, "Student 334" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000335"), 33, "Student 335" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000336"), 34, true, "Student 336" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000337"), 35, "Student 337" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000338"), 36, true, "Student 338" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000339"), 37, "Student 339" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000340"), 38, true, "Student 340" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000341"), 39, "Student 341" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000342"), 40, true, "Student 342" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000343"), 41, "Student 343" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000344"), 42, true, "Student 344" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000345"), 43, "Student 345" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000346"), 44, true, "Student 346" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000347"), 45, "Student 347" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000348"), 46, true, "Student 348" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000349"), 47, "Student 349" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000350"), 48, true, "Student 350" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000351"), 49, "Student 351" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000352"), 50, true, "Student 352" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000353"), 51, "Student 353" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000354"), 52, true, "Student 354" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000355"), 53, "Student 355" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000356"), 54, true, "Student 356" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000357"), 55, "Student 357" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000358"), 56, true, "Student 358" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000359"), 57, "Student 359" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000360"), 18, true, "Student 360" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000361"), 19, "Student 361" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000362"), 20, true, "Student 362" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000363"), 21, "Student 363" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000364"), 22, true, "Student 364" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000365"), 23, "Student 365" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000366"), 24, true, "Student 366" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000367"), 25, "Student 367" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000368"), 26, true, "Student 368" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000369"), 27, "Student 369" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000370"), 28, true, "Student 370" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000371"), 29, "Student 371" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000372"), 30, true, "Student 372" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000373"), 31, "Student 373" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000374"), 32, true, "Student 374" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000375"), 33, "Student 375" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000376"), 34, true, "Student 376" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000377"), 35, "Student 377" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000378"), 36, true, "Student 378" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000379"), 37, "Student 379" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000380"), 38, true, "Student 380" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000381"), 39, "Student 381" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000382"), 40, true, "Student 382" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000383"), 41, "Student 383" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000384"), 42, true, "Student 384" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000385"), 43, "Student 385" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000386"), 44, true, "Student 386" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000387"), 45, "Student 387" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000388"), 46, true, "Student 388" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000389"), 47, "Student 389" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000390"), 48, true, "Student 390" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000391"), 49, "Student 391" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000392"), 50, true, "Student 392" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000393"), 51, "Student 393" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000394"), 52, true, "Student 394" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000395"), 53, "Student 395" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000396"), 54, true, "Student 396" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000397"), 55, "Student 397" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000398"), 56, true, "Student 398" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000399"), 57, "Student 399" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000400"), 18, true, "Student 400" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000401"), 19, "Student 401" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000402"), 20, true, "Student 402" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000403"), 21, "Student 403" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000404"), 22, true, "Student 404" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000405"), 23, "Student 405" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000406"), 24, true, "Student 406" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000407"), 25, "Student 407" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000408"), 26, true, "Student 408" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000409"), 27, "Student 409" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000410"), 28, true, "Student 410" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000411"), 29, "Student 411" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000412"), 30, true, "Student 412" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000413"), 31, "Student 413" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000414"), 32, true, "Student 414" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000415"), 33, "Student 415" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000416"), 34, true, "Student 416" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000417"), 35, "Student 417" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000418"), 36, true, "Student 418" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000419"), 37, "Student 419" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000420"), 38, true, "Student 420" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000421"), 39, "Student 421" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000422"), 40, true, "Student 422" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000423"), 41, "Student 423" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000424"), 42, true, "Student 424" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000425"), 43, "Student 425" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000426"), 44, true, "Student 426" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000427"), 45, "Student 427" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000428"), 46, true, "Student 428" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000429"), 47, "Student 429" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000430"), 48, true, "Student 430" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000431"), 49, "Student 431" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000432"), 50, true, "Student 432" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000433"), 51, "Student 433" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000434"), 52, true, "Student 434" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000435"), 53, "Student 435" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000436"), 54, true, "Student 436" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000437"), 55, "Student 437" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000438"), 56, true, "Student 438" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000439"), 57, "Student 439" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000440"), 18, true, "Student 440" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000441"), 19, "Student 441" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000442"), 20, true, "Student 442" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000443"), 21, "Student 443" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000444"), 22, true, "Student 444" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000445"), 23, "Student 445" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000446"), 24, true, "Student 446" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000447"), 25, "Student 447" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000448"), 26, true, "Student 448" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000449"), 27, "Student 449" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000450"), 28, true, "Student 450" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000451"), 29, "Student 451" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000452"), 30, true, "Student 452" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000453"), 31, "Student 453" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000454"), 32, true, "Student 454" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000455"), 33, "Student 455" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000456"), 34, true, "Student 456" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000457"), 35, "Student 457" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000458"), 36, true, "Student 458" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000459"), 37, "Student 459" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000460"), 38, true, "Student 460" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000461"), 39, "Student 461" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000462"), 40, true, "Student 462" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000463"), 41, "Student 463" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000464"), 42, true, "Student 464" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000465"), 43, "Student 465" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000466"), 44, true, "Student 466" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000467"), 45, "Student 467" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000468"), 46, true, "Student 468" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000469"), 47, "Student 469" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000470"), 48, true, "Student 470" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000471"), 49, "Student 471" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000472"), 50, true, "Student 472" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000473"), 51, "Student 473" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000474"), 52, true, "Student 474" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000475"), 53, "Student 475" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000476"), 54, true, "Student 476" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000477"), 55, "Student 477" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000478"), 56, true, "Student 478" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000479"), 57, "Student 479" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000480"), 18, true, "Student 480" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000481"), 19, "Student 481" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000482"), 20, true, "Student 482" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000483"), 21, "Student 483" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000484"), 22, true, "Student 484" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000485"), 23, "Student 485" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000486"), 24, true, "Student 486" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000487"), 25, "Student 487" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000488"), 26, true, "Student 488" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000489"), 27, "Student 489" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000490"), 28, true, "Student 490" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000491"), 29, "Student 491" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000492"), 30, true, "Student 492" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000493"), 31, "Student 493" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000494"), 32, true, "Student 494" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000495"), 33, "Student 495" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000496"), 34, true, "Student 496" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000497"), 35, "Student 497" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000498"), 36, true, "Student 498" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000499"), 37, "Student 499" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000500"), 38, true, "Student 500" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000501"), 39, "Student 501" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000502"), 40, true, "Student 502" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000503"), 41, "Student 503" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000504"), 42, true, "Student 504" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000505"), 43, "Student 505" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000506"), 44, true, "Student 506" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000507"), 45, "Student 507" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000508"), 46, true, "Student 508" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000509"), 47, "Student 509" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000510"), 48, true, "Student 510" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000511"), 49, "Student 511" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000512"), 50, true, "Student 512" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000513"), 51, "Student 513" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000514"), 52, true, "Student 514" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000515"), 53, "Student 515" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000516"), 54, true, "Student 516" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000517"), 55, "Student 517" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000518"), 56, true, "Student 518" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000519"), 57, "Student 519" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000520"), 18, true, "Student 520" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000521"), 19, "Student 521" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000522"), 20, true, "Student 522" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000523"), 21, "Student 523" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000524"), 22, true, "Student 524" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000525"), 23, "Student 525" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000526"), 24, true, "Student 526" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000527"), 25, "Student 527" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000528"), 26, true, "Student 528" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000529"), 27, "Student 529" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000530"), 28, true, "Student 530" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000531"), 29, "Student 531" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000532"), 30, true, "Student 532" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000533"), 31, "Student 533" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000534"), 32, true, "Student 534" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000535"), 33, "Student 535" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000536"), 34, true, "Student 536" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000537"), 35, "Student 537" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000538"), 36, true, "Student 538" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000539"), 37, "Student 539" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000540"), 38, true, "Student 540" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000541"), 39, "Student 541" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000542"), 40, true, "Student 542" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000543"), 41, "Student 543" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000544"), 42, true, "Student 544" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000545"), 43, "Student 545" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000546"), 44, true, "Student 546" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000547"), 45, "Student 547" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000548"), 46, true, "Student 548" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000549"), 47, "Student 549" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000550"), 48, true, "Student 550" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000551"), 49, "Student 551" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000552"), 50, true, "Student 552" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000553"), 51, "Student 553" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000554"), 52, true, "Student 554" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000555"), 53, "Student 555" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000556"), 54, true, "Student 556" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000557"), 55, "Student 557" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000558"), 56, true, "Student 558" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000559"), 57, "Student 559" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000560"), 18, true, "Student 560" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000561"), 19, "Student 561" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000562"), 20, true, "Student 562" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000563"), 21, "Student 563" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000564"), 22, true, "Student 564" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000565"), 23, "Student 565" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000566"), 24, true, "Student 566" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000567"), 25, "Student 567" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000568"), 26, true, "Student 568" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000569"), 27, "Student 569" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000570"), 28, true, "Student 570" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000571"), 29, "Student 571" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000572"), 30, true, "Student 572" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000573"), 31, "Student 573" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000574"), 32, true, "Student 574" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000575"), 33, "Student 575" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000576"), 34, true, "Student 576" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000577"), 35, "Student 577" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000578"), 36, true, "Student 578" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000579"), 37, "Student 579" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000580"), 38, true, "Student 580" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000581"), 39, "Student 581" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000582"), 40, true, "Student 582" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000583"), 41, "Student 583" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000584"), 42, true, "Student 584" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000585"), 43, "Student 585" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000586"), 44, true, "Student 586" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000587"), 45, "Student 587" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000588"), 46, true, "Student 588" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000589"), 47, "Student 589" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000590"), 48, true, "Student 590" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000591"), 49, "Student 591" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000592"), 50, true, "Student 592" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000593"), 51, "Student 593" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000594"), 52, true, "Student 594" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000595"), 53, "Student 595" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000596"), 54, true, "Student 596" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000597"), 55, "Student 597" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000598"), 56, true, "Student 598" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000599"), 57, "Student 599" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000600"), 18, true, "Student 600" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000601"), 19, "Student 601" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000602"), 20, true, "Student 602" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000603"), 21, "Student 603" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000604"), 22, true, "Student 604" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000605"), 23, "Student 605" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000606"), 24, true, "Student 606" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000607"), 25, "Student 607" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000608"), 26, true, "Student 608" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000609"), 27, "Student 609" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000610"), 28, true, "Student 610" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000611"), 29, "Student 611" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000612"), 30, true, "Student 612" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000613"), 31, "Student 613" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000614"), 32, true, "Student 614" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000615"), 33, "Student 615" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000616"), 34, true, "Student 616" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000617"), 35, "Student 617" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000618"), 36, true, "Student 618" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000619"), 37, "Student 619" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000620"), 38, true, "Student 620" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000621"), 39, "Student 621" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000622"), 40, true, "Student 622" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000623"), 41, "Student 623" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000624"), 42, true, "Student 624" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000625"), 43, "Student 625" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000626"), 44, true, "Student 626" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000627"), 45, "Student 627" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000628"), 46, true, "Student 628" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000629"), 47, "Student 629" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000630"), 48, true, "Student 630" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000631"), 49, "Student 631" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000632"), 50, true, "Student 632" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000633"), 51, "Student 633" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000634"), 52, true, "Student 634" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000635"), 53, "Student 635" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000636"), 54, true, "Student 636" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000637"), 55, "Student 637" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000638"), 56, true, "Student 638" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000639"), 57, "Student 639" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000640"), 18, true, "Student 640" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000641"), 19, "Student 641" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000642"), 20, true, "Student 642" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000643"), 21, "Student 643" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000644"), 22, true, "Student 644" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000645"), 23, "Student 645" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000646"), 24, true, "Student 646" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000647"), 25, "Student 647" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000648"), 26, true, "Student 648" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000649"), 27, "Student 649" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000650"), 28, true, "Student 650" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000651"), 29, "Student 651" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000652"), 30, true, "Student 652" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000653"), 31, "Student 653" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000654"), 32, true, "Student 654" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000655"), 33, "Student 655" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000656"), 34, true, "Student 656" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000657"), 35, "Student 657" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000658"), 36, true, "Student 658" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000659"), 37, "Student 659" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000660"), 38, true, "Student 660" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000661"), 39, "Student 661" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000662"), 40, true, "Student 662" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000663"), 41, "Student 663" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000664"), 42, true, "Student 664" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000665"), 43, "Student 665" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000666"), 44, true, "Student 666" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000667"), 45, "Student 667" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000668"), 46, true, "Student 668" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000669"), 47, "Student 669" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000670"), 48, true, "Student 670" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000671"), 49, "Student 671" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000672"), 50, true, "Student 672" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000673"), 51, "Student 673" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000674"), 52, true, "Student 674" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000675"), 53, "Student 675" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000676"), 54, true, "Student 676" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000677"), 55, "Student 677" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000678"), 56, true, "Student 678" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000679"), 57, "Student 679" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000680"), 18, true, "Student 680" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000681"), 19, "Student 681" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000682"), 20, true, "Student 682" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000683"), 21, "Student 683" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000684"), 22, true, "Student 684" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000685"), 23, "Student 685" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000686"), 24, true, "Student 686" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000687"), 25, "Student 687" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000688"), 26, true, "Student 688" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000689"), 27, "Student 689" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000690"), 28, true, "Student 690" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000691"), 29, "Student 691" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000692"), 30, true, "Student 692" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000693"), 31, "Student 693" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000694"), 32, true, "Student 694" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000695"), 33, "Student 695" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000696"), 34, true, "Student 696" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000697"), 35, "Student 697" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000698"), 36, true, "Student 698" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000699"), 37, "Student 699" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000700"), 38, true, "Student 700" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000701"), 39, "Student 701" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000702"), 40, true, "Student 702" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000703"), 41, "Student 703" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000704"), 42, true, "Student 704" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000705"), 43, "Student 705" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000706"), 44, true, "Student 706" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000707"), 45, "Student 707" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000708"), 46, true, "Student 708" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000709"), 47, "Student 709" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000710"), 48, true, "Student 710" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000711"), 49, "Student 711" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000712"), 50, true, "Student 712" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000713"), 51, "Student 713" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000714"), 52, true, "Student 714" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000715"), 53, "Student 715" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000716"), 54, true, "Student 716" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000717"), 55, "Student 717" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000718"), 56, true, "Student 718" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000719"), 57, "Student 719" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000720"), 18, true, "Student 720" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000721"), 19, "Student 721" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000722"), 20, true, "Student 722" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000723"), 21, "Student 723" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000724"), 22, true, "Student 724" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000725"), 23, "Student 725" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000726"), 24, true, "Student 726" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000727"), 25, "Student 727" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000728"), 26, true, "Student 728" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000729"), 27, "Student 729" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000730"), 28, true, "Student 730" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000731"), 29, "Student 731" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000732"), 30, true, "Student 732" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000733"), 31, "Student 733" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000734"), 32, true, "Student 734" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000735"), 33, "Student 735" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000736"), 34, true, "Student 736" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000737"), 35, "Student 737" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000738"), 36, true, "Student 738" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000739"), 37, "Student 739" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000740"), 38, true, "Student 740" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000741"), 39, "Student 741" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000742"), 40, true, "Student 742" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000743"), 41, "Student 743" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000744"), 42, true, "Student 744" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000745"), 43, "Student 745" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000746"), 44, true, "Student 746" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000747"), 45, "Student 747" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000748"), 46, true, "Student 748" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000749"), 47, "Student 749" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000750"), 48, true, "Student 750" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000751"), 49, "Student 751" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000752"), 50, true, "Student 752" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000753"), 51, "Student 753" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000754"), 52, true, "Student 754" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000755"), 53, "Student 755" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000756"), 54, true, "Student 756" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000757"), 55, "Student 757" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000758"), 56, true, "Student 758" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000759"), 57, "Student 759" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000760"), 18, true, "Student 760" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000761"), 19, "Student 761" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000762"), 20, true, "Student 762" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000763"), 21, "Student 763" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000764"), 22, true, "Student 764" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000765"), 23, "Student 765" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000766"), 24, true, "Student 766" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000767"), 25, "Student 767" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000768"), 26, true, "Student 768" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000769"), 27, "Student 769" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000770"), 28, true, "Student 770" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000771"), 29, "Student 771" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000772"), 30, true, "Student 772" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000773"), 31, "Student 773" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000774"), 32, true, "Student 774" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000775"), 33, "Student 775" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000776"), 34, true, "Student 776" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000777"), 35, "Student 777" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000778"), 36, true, "Student 778" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000779"), 37, "Student 779" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000780"), 38, true, "Student 780" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000781"), 39, "Student 781" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000782"), 40, true, "Student 782" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000783"), 41, "Student 783" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000784"), 42, true, "Student 784" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000785"), 43, "Student 785" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000786"), 44, true, "Student 786" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000787"), 45, "Student 787" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000788"), 46, true, "Student 788" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000789"), 47, "Student 789" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000790"), 48, true, "Student 790" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000791"), 49, "Student 791" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000792"), 50, true, "Student 792" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000793"), 51, "Student 793" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000794"), 52, true, "Student 794" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000795"), 53, "Student 795" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000796"), 54, true, "Student 796" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000797"), 55, "Student 797" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000798"), 56, true, "Student 798" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000799"), 57, "Student 799" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000800"), 18, true, "Student 800" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000801"), 19, "Student 801" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000802"), 20, true, "Student 802" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000803"), 21, "Student 803" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000804"), 22, true, "Student 804" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000805"), 23, "Student 805" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000806"), 24, true, "Student 806" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000807"), 25, "Student 807" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000808"), 26, true, "Student 808" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000809"), 27, "Student 809" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000810"), 28, true, "Student 810" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000811"), 29, "Student 811" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000812"), 30, true, "Student 812" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000813"), 31, "Student 813" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000814"), 32, true, "Student 814" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000815"), 33, "Student 815" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000816"), 34, true, "Student 816" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000817"), 35, "Student 817" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000818"), 36, true, "Student 818" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000819"), 37, "Student 819" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000820"), 38, true, "Student 820" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000821"), 39, "Student 821" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000822"), 40, true, "Student 822" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000823"), 41, "Student 823" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000824"), 42, true, "Student 824" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000825"), 43, "Student 825" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000826"), 44, true, "Student 826" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000827"), 45, "Student 827" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000828"), 46, true, "Student 828" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000829"), 47, "Student 829" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000830"), 48, true, "Student 830" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000831"), 49, "Student 831" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000832"), 50, true, "Student 832" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000833"), 51, "Student 833" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000834"), 52, true, "Student 834" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000835"), 53, "Student 835" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000836"), 54, true, "Student 836" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000837"), 55, "Student 837" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000838"), 56, true, "Student 838" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000839"), 57, "Student 839" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000840"), 18, true, "Student 840" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000841"), 19, "Student 841" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000842"), 20, true, "Student 842" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000843"), 21, "Student 843" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000844"), 22, true, "Student 844" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000845"), 23, "Student 845" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000846"), 24, true, "Student 846" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000847"), 25, "Student 847" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000848"), 26, true, "Student 848" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000849"), 27, "Student 849" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000850"), 28, true, "Student 850" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000851"), 29, "Student 851" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000852"), 30, true, "Student 852" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000853"), 31, "Student 853" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000854"), 32, true, "Student 854" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000855"), 33, "Student 855" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000856"), 34, true, "Student 856" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000857"), 35, "Student 857" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000858"), 36, true, "Student 858" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000859"), 37, "Student 859" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000860"), 38, true, "Student 860" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000861"), 39, "Student 861" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000862"), 40, true, "Student 862" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000863"), 41, "Student 863" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000864"), 42, true, "Student 864" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000865"), 43, "Student 865" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000866"), 44, true, "Student 866" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000867"), 45, "Student 867" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000868"), 46, true, "Student 868" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000869"), 47, "Student 869" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000870"), 48, true, "Student 870" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000871"), 49, "Student 871" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000872"), 50, true, "Student 872" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000873"), 51, "Student 873" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000874"), 52, true, "Student 874" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000875"), 53, "Student 875" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000876"), 54, true, "Student 876" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000877"), 55, "Student 877" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000878"), 56, true, "Student 878" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000879"), 57, "Student 879" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000880"), 18, true, "Student 880" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000881"), 19, "Student 881" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000882"), 20, true, "Student 882" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000883"), 21, "Student 883" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000884"), 22, true, "Student 884" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000885"), 23, "Student 885" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000886"), 24, true, "Student 886" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000887"), 25, "Student 887" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000888"), 26, true, "Student 888" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000889"), 27, "Student 889" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000890"), 28, true, "Student 890" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000891"), 29, "Student 891" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000892"), 30, true, "Student 892" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000893"), 31, "Student 893" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000894"), 32, true, "Student 894" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000895"), 33, "Student 895" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000896"), 34, true, "Student 896" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000897"), 35, "Student 897" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000898"), 36, true, "Student 898" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000899"), 37, "Student 899" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000900"), 38, true, "Student 900" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000901"), 39, "Student 901" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000902"), 40, true, "Student 902" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000903"), 41, "Student 903" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000904"), 42, true, "Student 904" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000905"), 43, "Student 905" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000906"), 44, true, "Student 906" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000907"), 45, "Student 907" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000908"), 46, true, "Student 908" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000909"), 47, "Student 909" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000910"), 48, true, "Student 910" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000911"), 49, "Student 911" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000912"), 50, true, "Student 912" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000913"), 51, "Student 913" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000914"), 52, true, "Student 914" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000915"), 53, "Student 915" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000916"), 54, true, "Student 916" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000917"), 55, "Student 917" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000918"), 56, true, "Student 918" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000919"), 57, "Student 919" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000920"), 18, true, "Student 920" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000921"), 19, "Student 921" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000922"), 20, true, "Student 922" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000923"), 21, "Student 923" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000924"), 22, true, "Student 924" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000925"), 23, "Student 925" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000926"), 24, true, "Student 926" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000927"), 25, "Student 927" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000928"), 26, true, "Student 928" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000929"), 27, "Student 929" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000930"), 28, true, "Student 930" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000931"), 29, "Student 931" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000932"), 30, true, "Student 932" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000933"), 31, "Student 933" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000934"), 32, true, "Student 934" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000935"), 33, "Student 935" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000936"), 34, true, "Student 936" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000937"), 35, "Student 937" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000938"), 36, true, "Student 938" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000939"), 37, "Student 939" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000940"), 38, true, "Student 940" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000941"), 39, "Student 941" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000942"), 40, true, "Student 942" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000943"), 41, "Student 943" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000944"), 42, true, "Student 944" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000945"), 43, "Student 945" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000946"), 44, true, "Student 946" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000947"), 45, "Student 947" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000948"), 46, true, "Student 948" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000949"), 47, "Student 949" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000950"), 48, true, "Student 950" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000951"), 49, "Student 951" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000952"), 50, true, "Student 952" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000953"), 51, "Student 953" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000954"), 52, true, "Student 954" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000955"), 53, "Student 955" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000956"), 54, true, "Student 956" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000957"), 55, "Student 957" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000958"), 56, true, "Student 958" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000959"), 57, "Student 959" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000960"), 18, true, "Student 960" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000961"), 19, "Student 961" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000962"), 20, true, "Student 962" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000963"), 21, "Student 963" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000964"), 22, true, "Student 964" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000965"), 23, "Student 965" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000966"), 24, true, "Student 966" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000967"), 25, "Student 967" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000968"), 26, true, "Student 968" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000969"), 27, "Student 969" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000970"), 28, true, "Student 970" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000971"), 29, "Student 971" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000972"), 30, true, "Student 972" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000973"), 31, "Student 973" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000974"), 32, true, "Student 974" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000975"), 33, "Student 975" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000976"), 34, true, "Student 976" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000977"), 35, "Student 977" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000978"), 36, true, "Student 978" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000979"), 37, "Student 979" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000980"), 38, true, "Student 980" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000981"), 39, "Student 981" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000982"), 40, true, "Student 982" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000983"), 41, "Student 983" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000984"), 42, true, "Student 984" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000985"), 43, "Student 985" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000986"), 44, true, "Student 986" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000987"), 45, "Student 987" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000988"), 46, true, "Student 988" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000989"), 47, "Student 989" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000990"), 48, true, "Student 990" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000991"), 49, "Student 991" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000992"), 50, true, "Student 992" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000993"), 51, "Student 993" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000994"), 52, true, "Student 994" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000995"), 53, "Student 995" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000996"), 54, true, "Student 996" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000997"), 55, "Student 997" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000998"), 56, true, "Student 998" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000999"), 57, "Student 999" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "IsRegularStudent", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000001000"), 18, true, "Student 1000" });

            migrationBuilder.InsertData(
                table: "StudentDetails",
                columns: new[] { "StudentDetailsId", "AdditionalInformation", "Address", "StudentId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Senior Solution Architecture", "Ha Noi", new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Senior Solution Architecture", "Ha Noi", new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Senior Solution Architecture", "Ha Noi", new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Senior Solution Architecture", "Ha Noi", new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentId",
                table: "Evaluations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
