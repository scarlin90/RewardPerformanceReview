using Microsoft.EntityFrameworkCore;
using PerformanceReview.Data.EntityFramework.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public interface IRepository<R> where R : DbContext
    {
        IEnumerable<T> GetAll<T>() where T : BaseEntity;
        T Get<T>(long id) where T : BaseEntity;
        void Insert<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;

        IAsyncEnumerable<T> GetAllAsync<T>() where T : BaseEntity;
        Task<T> GetAsync<T>(long id) where T : BaseEntity;
        Task InsertAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
