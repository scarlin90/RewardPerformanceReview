using System.Collections.Generic;

namespace PerformanceReview.Data.EntityFramework.Entity
{
    public class Employee : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        List<EmployeeReview> EmployeeReviews { get; set; }
    }
}
