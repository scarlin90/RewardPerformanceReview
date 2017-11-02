using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DemoApi.Data.Migrations
{
    public partial class RemoveDuplicateEmployeeReviewKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_EmployeeReviews_EmployeeReviewId1",
                table: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceReviews_EmployeeReviewId1",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "EmployeeReviewId1",
                table: "PerformanceReviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeReviewId1",
                table: "PerformanceReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_EmployeeReviewId1",
                table: "PerformanceReviews",
                column: "EmployeeReviewId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_EmployeeReviews_EmployeeReviewId1",
                table: "PerformanceReviews",
                column: "EmployeeReviewId1",
                principalTable: "EmployeeReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
