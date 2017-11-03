using PerformanceReview.Data.EntityFramework.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public class EmployeeRepository : Repository<Employee, PerformanceReviewContext>, IEmployeeRepository
    {
        public EmployeeRepository(PerformanceReviewContext dbContext): base(dbContext)
        {

        }

        public async Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return await GetAllAsync().FirstOrDefault(f => f.Username == username);
        }
    }
}
