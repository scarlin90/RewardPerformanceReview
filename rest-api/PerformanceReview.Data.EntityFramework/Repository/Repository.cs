using Microsoft.EntityFrameworkCore;
using PerformanceReview.Data.EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceReview.Data.EntityFramework.Repository
{
    public class Repository<T,R> : IRepository<T,R> where T : BaseEntity 
                                                    where R : DbContext
    {
        #region Private Properties

        private readonly R context;
        private DbSet<T> entities;

        #endregion

        #region Constructor

        public Repository(R context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        #endregion

        #region Sync Methods

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IQueryable<T> Filter()
        {
            return entities.AsNoTracking();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        #endregion

        #region Async Methods

        public IAsyncEnumerable<T> GetAllAsync()
        {
            return entities.ToAsyncEnumerable();
        }

        public async Task<T> GetAsync(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        #endregion
    }
}
