using Microsoft.EntityFrameworkCore;
using PerformanceReview.Data.EntityFramework.Entity;

namespace PerformanceReview.Data.EntityFramework
{
    public class PerformanceReviewContext : DbContext
    {
        public PerformanceReviewContext(DbContextOptions<PerformanceReviewContext> options)
            : base(options)
        { }

        public DbSet<AssignedReviewer> AssignedReviewers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeReview> EmployeeReviews { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Entity.PerformanceReview> PerformanceReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
