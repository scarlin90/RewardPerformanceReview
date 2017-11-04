﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PerformanceReview.Data.EntityFramework;
using System;

namespace PerformanceReview.Data.EntityFramework.Migrations
{
    [DbContext(typeof(PerformanceReviewContext))]
    partial class PerformanceReviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.AssignedReviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreTime");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("ModTime");

                    b.Property<int>("PerformanceReviewId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PerformanceReviewId");

                    b.ToTable("AssignedReviewers");
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreTime");

                    b.Property<bool>("IsAdmin");

                    b.Property<DateTime>("ModTime");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.EmployeeReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreTime");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("ModTime");

                    b.Property<int>("PerformanceReviewId");

                    b.HasKey("Id");

                    b.ToTable("EmployeeReviews");
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreTime");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("ModTime");

                    b.Property<int>("PerformanceReviewId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PerformanceReviewId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.PerformanceReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreTime");

                    b.Property<int>("EmployeeReviewId");

                    b.Property<DateTime>("ModTime");

                    b.Property<string>("ReviewBody");

                    b.HasKey("Id");

                    b.ToTable("PerformanceReviews");
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.AssignedReviewer", b =>
                {
                    b.HasOne("PerformanceReview.Data.EntityFramework.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerformanceReview.Data.EntityFramework.Entity.PerformanceReview", "PerformanceReview")
                        .WithMany()
                        .HasForeignKey("PerformanceReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PerformanceReview.Data.EntityFramework.Entity.Feedback", b =>
                {
                    b.HasOne("PerformanceReview.Data.EntityFramework.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PerformanceReview.Data.EntityFramework.Entity.PerformanceReview", "PerformanceReview")
                        .WithMany()
                        .HasForeignKey("PerformanceReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
