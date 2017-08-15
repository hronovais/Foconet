using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foconet.Data.Core.Base
{
    public abstract class Repository<C, TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : class
        where C : DbContext, new()
    {
        private C dbContext = new C();
        public C DbContext { get { return dbContext; } set { dbContext = value; } }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var x = await dbContext.Set<TEntity>().Where(predicate).ToListAsync();
            return x.AsQueryable<TEntity>();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().Where(predicate).ToListAsync<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> dbQuery = dbContext.Set<TEntity>().Where(predicate);

            foreach (Expression<Func<TEntity, object>> include in includes)
                dbQuery = dbQuery.Include<TEntity, object>(include);

            dbQuery
                .AsNoTracking()
                .AsParallel();

            return dbQuery;
        }

        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> dbQuery = dbContext.Set<TEntity>().Where(predicate);

            foreach (Expression<Func<TEntity, object>> include in includes)
                dbQuery = dbQuery.Include<TEntity, object>(include);

            return await dbQuery
                .AsNoTracking()
                .ToListAsync();
        }

        public TEntity Find(params object[] key)
        {
            return dbContext.Set<TEntity>().Find(key);
        }

        public async Task<TEntity> FindAsync(params object[] key)
        {
            return await dbContext.Set<TEntity>().FindAsync(key);
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public async Task AddAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddRange(IList<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
            await dbContext.SaveChangesAsync();
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            dbContext.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => dbContext.Set<TEntity>().Remove(del));
            dbContext.SaveChanges();
        }

        public async Task DeleteAsync(Func<TEntity, bool> predicate)
        {
            dbContext.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => dbContext.Set<TEntity>().Remove(del));
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
