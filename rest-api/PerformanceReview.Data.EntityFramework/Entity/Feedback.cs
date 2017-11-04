
namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class Feedback : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int EmployeeReviewId { get; set; }

        public EmployeeReview EmployeeReview { get; set; }

        public string Comment { get; set; }
    }
}
