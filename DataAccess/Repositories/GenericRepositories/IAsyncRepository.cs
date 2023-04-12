using Entities.Common;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories
{
    public interface IAsyncRepository<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        Task<List<TDto>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TDto> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TDto> AddAsync(TDto entityDto);
        Task<TDto> DeleteAsync(TDto entityDto);
    }
}
