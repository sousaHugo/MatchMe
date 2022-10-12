using MongoDB.Driver;
using System.Linq.Expressions;


namespace MatchMe.Common.Shared.MongoDb
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IMongoEntity
    {

        private readonly IMongoCollection<T> _dbCollection;
        private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _dbCollection = database.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbCollection.Find(filter).ToListAsync();
        }
        public async Task<T> GetAsync(long Id)
        {
            var filter = _filterBuilder.Eq(entity => entity.Id, Id);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter)
        {
            return await _dbCollection.Find(Filter).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(T Entity)
        {
            if (Entity == null)
                throw new ArgumentException(nameof(Entity));

            await _dbCollection.InsertOneAsync(Entity);
        }

        public async Task UpdateAsync(T Entity)
        {
            if (Entity == null)
                throw new ArgumentException(nameof(Entity));


            var filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, Entity.Id);


            await _dbCollection.ReplaceOneAsync(filter, Entity);
        }

        public async Task RemoveAsync(long Id)
        {
            var filter = _filterBuilder.Eq(entity => entity.Id, Id);

            await _dbCollection.DeleteOneAsync(filter);
        }
    }
}
