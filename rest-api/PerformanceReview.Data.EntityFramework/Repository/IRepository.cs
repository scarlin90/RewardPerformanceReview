using Microsoft.EntityFrameworkCore;
using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public interface IRepository<T, R> where T : BaseEntity
                                       where R : DbContext
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        IAsyncEnumerable<T> GetAllAsync();
        Task<T> GetAsync(long id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
    }
}
