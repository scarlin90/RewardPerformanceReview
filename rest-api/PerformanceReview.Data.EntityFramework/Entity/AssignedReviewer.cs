
namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class AssignedReviewer : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int PerformanceReviewId { get; set; }

        public PerformanceReview PerformanceReview { get; set; }
    }
}
