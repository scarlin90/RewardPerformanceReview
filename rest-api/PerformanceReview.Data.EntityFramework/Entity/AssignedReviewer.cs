
namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class AssignedReviewer : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int EmployeeReviewId { get; set; }

        public EmployeeReview EmployeeReview { get; set; }
    }
}
