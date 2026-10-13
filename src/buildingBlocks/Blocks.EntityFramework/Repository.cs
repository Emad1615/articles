using Blocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blocks.EntityFramework
{
    public interface IRepository<TEntity>
    {
        Task<TEntity?> FindByIdAsync(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> AddAsync(TEntity entity);
        TEntity UpdateAsync(TEntity entity);
        void remove(TEntity entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> SaveChangeAsync(CancellationToken ct);
    }
    public class Repository<TContext, TEntity>
        where TContext : DbContext where TEntity : class, IEntity
    {

        protected readonly TContext _dbContext;
        protected readonly DbSet<TEntity> _entity;
        public Repository(TContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _entity = dbContext.Set<TEntity>();
        }

        public DbContext Context => _dbContext;
        public virtual DbSet<TEntity> Entity => _entity;

        protected virtual IQueryable<TEntity> Query => _entity;

        public string TableName => _dbContext.Model.FindEntityType(typeof(TEntity))?.GetTableName()!;

        #region methods

        public virtual async Task<TEntity?> FindByIdAsync(int id) => await _entity.FindAsync(id);

        public virtual async Task<TEntity?> GetByIdAsync(int id) => await Query.SingleOrDefaultAsync(a => a.Id.Equals(id));

        public virtual async Task<TEntity> AddAsync(TEntity entity) => (await _entity.AddAsync(entity)).Entity;
        public virtual void remove(TEntity entity) => _entity.Remove(entity);

        public virtual async Task<bool> DeleteByIdAsync(int id) {
            var rowEffected = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM {TableName} WHERE Id={id}");
            return rowEffected > 0;
        }


        public async Task<int> SaveChangeAsync(CancellationToken ct) => await _dbContext.SaveChangesAsync(ct);
        
        #endregion
    }
}
