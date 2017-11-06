using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PerformanceReview.Web.Rest.Migrations
{
    public partial class Refactor_Remove_One_To_One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedReviewers_PerformanceReviews_PerformanceReviewId",
                table: "AssignedReviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_PerformanceReviews_PerformanceReviewId",
                table: "Feedback");

            migrationBuilder.DropTable(
                name: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_PerformanceReviewId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_AssignedReviewers_PerformanceReviewId",
                table: "AssignedReviewers");

            migrationBuilder.DropColumn(
                name: "PerformanceReviewId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "PerformanceReviewId",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "PerformanceReviewId",
                table: "AssignedReviewers");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeReviewId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aspirations",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Communications",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveringResults",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Leadership",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objectives",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverallPerformance",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalPerformance",
                table: "EmployeeReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeReviewId",
                table: "AssignedReviewers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_EmployeeReviewId",
                table: "Feedback",
                column: "EmployeeReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedReviewers_EmployeeReviewId",
                table: "AssignedReviewers",
                column: "EmployeeReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedReviewers_EmployeeReviews_EmployeeReviewId",
                table: "AssignedReviewers",
                column: "EmployeeReviewId",
                principalTable: "EmployeeReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_EmployeeReviews_EmployeeReviewId",
                table: "Feedback",
                column: "EmployeeReviewId",
                principalTable: "EmployeeReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedReviewers_EmployeeReviews_EmployeeReviewId",
                table: "AssignedReviewers");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_EmployeeReviews_EmployeeReviewId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_EmployeeReviewId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_AssignedReviewers_EmployeeReviewId",
                table: "AssignedReviewers");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "EmployeeReviewId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Aspirations",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "Communications",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "DeliveringResults",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "Leadership",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "Objectives",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "OverallPerformance",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "TechnicalPerformance",
                table: "EmployeeReviews");

            migrationBuilder.DropColumn(
                name: "EmployeeReviewId",
                table: "AssignedReviewers");

            migrationBuilder.AddColumn<int>(
                name: "PerformanceReviewId",
                table: "Feedback",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerformanceReviewId",
                table: "EmployeeReviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerformanceReviewId",
                table: "AssignedReviewers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PerformanceReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreTime = table.Column<DateTime>(nullable: false),
                    ModTime = table.Column<DateTime>(nullable: false),
                    ReviewBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceReviews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PerformanceReviewId",
                table: "Feedback",
                column: "PerformanceReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedReviewers_PerformanceReviewId",
                table: "AssignedReviewers",
                column: "PerformanceReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedReviewers_PerformanceReviews_PerformanceReviewId",
                table: "AssignedReviewers",
                column: "PerformanceReviewId",
                principalTable: "PerformanceReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_PerformanceReviews_PerformanceReviewId",
                table: "Feedback",
                column: "PerformanceReviewId",
                principalTable: "PerformanceReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
