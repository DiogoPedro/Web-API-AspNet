using MongoDB.Bson;
using MongoDB.Driver;

namespace Web_API_AspNet.Services
{
    public class BaseService<T>
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoDatabase _database;

        public BaseService(IMongoClient mongoClient, string collectionName, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(collectionName);
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
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        //public async Task<T> ReadAsync(string id)
        //{
        //    var filter = Builders<T>.Filter.Eq("ObjectId", id);
        //    return await _collection.Find(filter).FirstOrDefaultAsync();
        //}

        public async Task<T> ReadAsync(string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                return await _collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


        public async Task<List<T>> ReadAllAsync()
        {
            try
            {
                var filter = Builders<T>.Filter.Empty;
                return await _collection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }   

        public async Task<T> UpdateAsync(string id, T entity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                await _collection.ReplaceOneAsync(filter, entity);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<T> DeleteAsync(string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", id);
                return await _collection.FindOneAndDeleteAsync(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
