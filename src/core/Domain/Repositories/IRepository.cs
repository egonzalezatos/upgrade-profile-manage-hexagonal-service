using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity?> FindById(int id);
        void Insert(TEntity hero);
        void Delete(int id);
        void Update(TEntity hero);
        Task<int> Save();
    }
}