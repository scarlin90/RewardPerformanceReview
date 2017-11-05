using Microsoft.EntityFrameworkCore;
using PerformanceReview.Data.EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public class Repository<R> : IRepository<R> where R : DbContext
    {
        #region Private Properties

        private readonly R context;
        

        #endregion

        #region Constructor

        public Repository(R context)
        {
            this.context = context;
           
        }

        #endregion

        #region Sync Methods

        public IEnumerable<T> GetAll<T>() where T : BaseEntity
        {
            return context.Set<T>().AsEnumerable();
        }

        public IQueryable<T> Filter<T>() where T : BaseEntity
        {
            return context.Set<T>().AsNoTracking();
        }

        public T Get<T>(long id) where T : BaseEntity
        {
            return context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public void Insert<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.ModTime = DateTime.Now;
            context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public bool Exists<T>(int id) where T : BaseEntity
        {
            return (GetAll<T>().FirstOrDefault(f => f.Id == id) == null) ? false : true;
        }

        #endregion

        #region Async Methods

        public IAsyncEnumerable<T> GetAllAsync<T>() where T : BaseEntity
        {
            return context.Set<T>().ToAsyncEnumerable();
        }

        public async Task<T> GetAsync<T>(long id) where T : BaseEntity
        {
            return await context.Set<T>().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task InsertAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        #endregion
    }
}
