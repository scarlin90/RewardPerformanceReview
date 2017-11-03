using PerformanceReview.Data.EntityFramework.Entity;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public interface IEmployeeRepository : IRepository<Employee, PerformanceReviewContext>
    {
        Task<Employee> GetEmployeeByUsernameAsync(string username);
    }
}
