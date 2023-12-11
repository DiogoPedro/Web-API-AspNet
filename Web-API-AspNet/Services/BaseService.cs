using MongoDB.Driver;

namespace Web_API_AspNet.Services
{
    public class BaseService<T>
    {
        private readonly IMongoCollection<T> _collection;

        public BaseService(IMongoClient mongoClient, string collectionName, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> ReadAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
            return entity;
        }

        public async Task<T> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.FindOneAndDeleteAsync(filter);
        }
    }
}
