
namespace PerformanceReview.Web.Rest.Models
{
    public class UpdateEmployeeDto 
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
    }
}
