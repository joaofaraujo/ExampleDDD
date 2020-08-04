using Inception.Data.Contexts;
using Inception.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inception.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public InceptionContext InceptionContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }
        protected BaseRepository(InceptionContext inceptionContext)
        {
            InceptionContext = inceptionContext;
        }

        public virtual void Insert(T entity)
        {
            InceptionContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            InceptionContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            InceptionContext.Set<T>().Remove(entity);
        }

        public virtual T FindById(long id)
        {
            return InceptionContext.Set<T>().Find(id);
        }

        protected IQueryable<T> Select(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = InceptionContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            query = query.Where(predicate).AsQueryable();

            return query;
        }

        protected IQueryable<T> SelectAll(params Expression<Func<T, object>>[] includes)
        {
            var query = InceptionContext.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public int Save()
        {
            return InceptionContext.SaveChanges();
        }

        public virtual async Task<bool> InsertAsync(T entidade)
        {
            InceptionContext.Set<T>().Add(entidade);
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            InceptionContext.Entry(entity).State = EntityState.Modified;
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            InceptionContext.Set<T>().Remove(entity);
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<T> FindByIdAsync(long id)
        {
            return await InceptionContext.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await InceptionContext.SaveChangesAsync().ConfigureAwait(false);
        }

        protected async Task<IList<T>> SelectAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = InceptionContext.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        protected async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = InceptionContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            query = query.Where(predicate);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public void OpenTransaction(IsolationLevel? isolationLevel)
        {
            if (isolationLevel.HasValue)
                DbContextTransaction = InceptionContext.Database.BeginTransaction(isolationLevel.Value);
            else
                DbContextTransaction = InceptionContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            DbContextTransaction?.Commit();
        }

        public void RollbackTransaction()
        {
            DbContextTransaction.Rollback();
        }

        private async Task<int> CommitAsync()
        {
            return await InceptionContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
