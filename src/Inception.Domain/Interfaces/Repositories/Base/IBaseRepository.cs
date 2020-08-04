using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inception.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(long id);
        int Save();
        Task<bool> InsertAsync(T entidade);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> FindByIdAsync(long id);
        Task<int> SaveAsync();
        void OpenTransaction(IsolationLevel? isolationLevel = null);
        void CommitTransaction();
        void RollbackTransaction();
    }
}
