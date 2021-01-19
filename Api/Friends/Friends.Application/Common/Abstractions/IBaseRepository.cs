using System.Threading.Tasks;
using System.Collections.Generic;

namespace Friends.Application.Common.Abstractions
{
    public interface IBaseRepository<TEntity, TKey>
         where TEntity : class
         where TKey : notnull
    {
        Task<List<TEntity>> GetAllAsync();
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
