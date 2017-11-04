using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PerformanceReview.Web.Rest.Migrations
{
    public partial class PerformanceReview_Remove_EReviewLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ModTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformanceReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ModTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedReviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ModTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformanceReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedReviewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedReviewers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedReviewers_PerformanceReviews_PerformanceReviewId",
                        column: x => x.PerformanceReviewId,
                        principalTable: "PerformanceReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ModTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformanceReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_PerformanceReviews_PerformanceReviewId",
                        column: x => x.PerformanceReviewId,
                        principalTable: "PerformanceReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedReviewers_EmployeeId",
                table: "AssignedReviewers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedReviewers_PerformanceReviewId",
                table: "AssignedReviewers",
                column: "PerformanceReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_EmployeeId",
                table: "Feedback",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PerformanceReviewId",
                table: "Feedback",
                column: "PerformanceReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedReviewers");

            migrationBuilder.DropTable(
                name: "EmployeeReviews");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PerformanceReviews");
        }
    }
}
