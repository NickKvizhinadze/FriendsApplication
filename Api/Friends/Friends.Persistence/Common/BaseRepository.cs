#nullable disable
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DotNetHelpers.Extentions;
using Friends.Application.Common.Abstractions;

namespace Friends.Persistence.Common
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
           where TEntity : class
           where TKey : notnull
    {
        #region Fields

        protected readonly ApplicationDbContext _context;
        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Properties

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }

                return _entities;
            }
        }

        protected IQueryable<TEntity> Table
        {
            get { return Entities; }
        }

        protected IQueryable<TEntity> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        #endregion

        #region Methods
        public async virtual Task<List<TEntity>> GetAllAsync() =>
                    await TableNoTracking.ToListAsync();

        public virtual TEntity Get(TKey id)
        {
            return Entities.Find(id);
        }

        public async virtual Task<TEntity> GetAsync(TKey id)
            => await Entities.FindAsync(id);

        public virtual void Add(TEntity entity)
        {
            entity.ThrowIfNull(nameof(entity));

            Entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            entities.ThrowIfNull(nameof(entities));

            _context.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            entity.ThrowIfNull(nameof(entity));

            Entities.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            entities.ThrowIfNull(nameof(entities));

            _context.RemoveRange(entities);
        }
        #endregion        
    }
}
