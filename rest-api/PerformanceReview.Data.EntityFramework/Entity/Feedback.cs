
namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class Feedback : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int PerformanceReviewId { get; set; }

        public PerformanceReview PerformanceReview { get; set; }
    }
}
