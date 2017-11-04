
namespace PerformanceReview.Web.Rest.Models
{
    public class EmployeeDto : BaseDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
