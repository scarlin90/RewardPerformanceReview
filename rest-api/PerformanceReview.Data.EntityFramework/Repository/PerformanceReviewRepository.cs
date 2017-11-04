using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public class PerformanceReviewRepository : Repository<PerformanceReviewContext>, IPerformanceReviewRepository
    {
        public PerformanceReviewRepository(PerformanceReviewContext dbContext): base(dbContext)
        {

        }

        public async Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return await GetAllAsync<Employee>().FirstOrDefault(f => f.Username == username);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return GetAll<Employee>().FirstOrDefault(f => f.Username == username);
        }

        public bool EmployeeExists(int employeeId)
        {
            return (GetAll<Employee>().FirstOrDefault(f => f.Id == employeeId) == null) ? false : true;
        }

        public IEnumerable<EmployeeReview> GetEmployeeReviewsForEmployee(int employeeId)
        {
            return GetAll<EmployeeReview>().Where(er => er.EmployeeId == employeeId);
        }

        public EmployeeReview GetEmployeeReviewForEmployee(int employeeId, int id)
        {
            return GetAll<EmployeeReview>().FirstOrDefault(er => er.EmployeeId == employeeId && er.Id == id);
        }
    }
}
