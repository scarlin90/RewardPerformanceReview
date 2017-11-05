
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class FeedbackDto : BaseDto
    {
        public int EmployeeId { get; set; }

        public int EmployeeReviewId { get; set; }

        public string Comment { get; set; }
    }
}
