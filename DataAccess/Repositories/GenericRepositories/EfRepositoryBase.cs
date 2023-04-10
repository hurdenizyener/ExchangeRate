using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IDisposable
    where TEntity : class, IEntity, new()
    where TContext : DbContext
    {
        protected TContext Context { get; }
        private readonly ILogger<EfRepositoryBase<TEntity, TContext>> _logger;


        public EfRepositoryBase(TContext context, ILogger<EfRepositoryBase<TEntity, TContext>> logger)
        {
            Context = context;
            _logger = logger;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanına Kayıt Eklenemedi.");
                return null;
            }

        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Deleted;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanından Kayıt Silinemedi.");
                return null;
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return predicate != null ? await Context.Set<TEntity>().Where(predicate).ToListAsync() : await Context.Set<TEntity>().ToListAsync();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Veritabanından Nesne Listesi Alınamadı.");
                return null;
            }

        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanından Nesne Alınamadı.");
                return null;
            }
         
        }

        public void Dispose()
        {
            Context.DisposeAsync();
        }
    }
}
