using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public interface IPerformanceReviewRepository : IRepository<PerformanceReviewContext>
    {
        Task<Employee> GetEmployeeByUsernameAsync(string username);

        Employee GetEmployeeByUsername(string username);

        IEnumerable<EmployeeReview> GetEmployeeReviewsForEmployee(int employeeId);

        bool EmployeeExists(int employeeId);

        EmployeeReview GetEmployeeReviewForEmployee(int employeeId, int id);
    }
}
