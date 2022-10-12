using System.Linq.Expressions;

namespace MatchMe.Common.Shared.MongoDb
{
    public interface IMongoRepository<T> where T : IMongoEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> Filter);
        Task<T> GetAsync(long Id);
        Task<T> GetAsync(Expression<Func<T, bool>> Filter);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task RemoveAsync(long Id);
    }
}
