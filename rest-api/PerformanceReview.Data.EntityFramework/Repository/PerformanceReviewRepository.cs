using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public class PerformanceReviewRepository : Repository<PerformanceReviewContext>, IPerformanceReviewRepository
    {
        public PerformanceReviewRepository(PerformanceReviewContext dbContext): base(dbContext)
        {
        }

        public IEnumerable<EmployeeReview> GetEmployeeReviewsForEmployee(int employeeId)
        {
            return GetAll<EmployeeReview>().Where(er => er.EmployeeId == employeeId);
        }

        public EmployeeReview GetEmployeeReviewForEmployee(int employeeId, int id)
        {
            return GetAll<EmployeeReview>().FirstOrDefault(er => er.EmployeeId == employeeId && er.Id == id);
        }

        public IEnumerable<Feedback> GetFeedbackForEmployeeReviews(int employeeReviewId)
        {
            return GetAll<Feedback>().Where(er => er.EmployeeReviewId == employeeReviewId);
        }

        public Feedback GetFeedbackForEmployeeReview(int employeeReviewId, int id)
        {
            return GetAll<Feedback>().FirstOrDefault(er => er.EmployeeReviewId == employeeReviewId && er.Id == id);
        }
    }
}
