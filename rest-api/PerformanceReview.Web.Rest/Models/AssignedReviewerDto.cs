
using PerformanceReview.Web.Rest.Models;

namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class AssignedReviewerDto : BaseDto
    {

        public int EmployeeId { get; set; }

        public int PerformanceReviewId { get; set; }
    }
}
