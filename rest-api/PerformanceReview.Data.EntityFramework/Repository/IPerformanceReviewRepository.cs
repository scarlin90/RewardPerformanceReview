using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public interface IPerformanceReviewRepository : IRepository<PerformanceReviewContext>
    {
        IEnumerable<EmployeeReview> GetEmployeeReviewsForEmployee(int employeeId);

        EmployeeReview GetEmployeeReviewForEmployee(int employeeId, int id);

        IEnumerable<Feedback> GetFeedbackForEmployeeReviews(int employeeReviewId);

        Feedback GetFeedbackForEmployeeReview(int employeeReviewId, int id);


    }
}
