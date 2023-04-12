using AutoMapper;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories
{
    public class EfRepositoryBase<TEntity, TDto, TContext> : IAsyncRepository<TEntity, TDto>, IDisposable
    where TEntity : class, IEntity, new()
    where TDto : class, IDto, new()
    where TContext : DbContext
    {
        protected TContext Context { get; }
        //  private readonly DbSet<TEntity> _entities; 
        private readonly IMapper _mapper;
        private readonly ILogger<EfRepositoryBase<TEntity, TDto, TContext>> _logger;


        public EfRepositoryBase(TContext context, ILogger<EfRepositoryBase<TEntity, TDto, TContext>> logger, IMapper mapper)
        {
            Context = context;
            _logger = logger;
            _mapper = mapper;
            //  _entities = entities;
        }

        public async Task<TDto> AddAsync(TDto entityDto)
        {
            try
            {
                var entity = _mapper.Map<TDto, TEntity>(entityDto);
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();
                return entityDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanına Kayıt Eklenemedi.");
                return null;
            }

        }


        public async Task<TDto> DeleteAsync(TDto entityDto)
        {
            try
            {
                var entity = _mapper.Map<TDto, TEntity>(entityDto);
                Context.Entry(entity).State = EntityState.Deleted;
                await Context.SaveChangesAsync();
                return entityDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Veritabanına Kayıt Eklenemedi.");
                return null;
            }

        }

        public async Task<List<TDto>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {

                IQueryable<TEntity> query = Context.Set<TEntity>();

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                var entities = await query.ToListAsync();
                var dtos = _mapper.Map<List<TEntity>, List<TDto>>(entities);
                return dtos;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Veritabanından Nesne Listesi Alınamadı.");
                return null;
            }

        }

        public async Task<TDto> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {

                IQueryable<TEntity> query = Context.Set<TEntity>();
                query = query.Where(predicate);

                var entity = await query.FirstOrDefaultAsync();
                var dto = _mapper.Map<TEntity, TDto>(entity);

                return dto;


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
