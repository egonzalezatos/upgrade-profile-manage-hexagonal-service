using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly EntityContext _entityContext;
        protected DbSet<TEntity> dbSet { get; set; }

        public Repository(EntityContext entityContext)
        {
            _entityContext = entityContext;
            dbSet = _entityContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            List<TEntity> list = await dbSet.ToListAsync();
            return list;
        }

        public virtual async Task<TEntity?> FindById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual async void Delete(int id)
        {
            TEntity? entity = await dbSet.FindAsync(id);
            if (entity != null)
                dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual Task<int> Save()
        {
            return _entityContext.SaveChangesAsync();
        }
    }
}