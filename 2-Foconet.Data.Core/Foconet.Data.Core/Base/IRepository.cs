using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Core.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        TEntity Find(params object[] key);
        Task<TEntity> FindAsync(params object[] key);
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        void Save();
        Task SaveAsync();
        void Delete(Func<TEntity, bool> predicate);
        Task DeleteAsync(Func<TEntity, bool> predicate);
    }
}
