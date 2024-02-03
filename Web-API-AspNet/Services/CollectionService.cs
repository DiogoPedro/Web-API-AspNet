using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Web_API_AspNet.Entity;

namespace Web_API_AspNet.Services
{
    public class CollectionService
    {
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<BsonDocument> _mongoCollection;

        public CollectionService(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public void CreateCollection(string dataset, Collection collection, Data entity)
        {
            try
            {
                _mongoCollection = _mongoDatabase.GetCollection<BsonDocument>("DataColectionTable");
                var collections = _mongoDatabase.ListCollectionNames().ToList();

                if (!collections.Contains(collection.Id))
                {
                    // Criação do dataset e da coleção
                    var datasetCollection = _mongoDatabase.GetCollection<BsonDocument>(collection.NameCollection);
                    var datasetDocument = new BsonDocument
                    {
                        {"name", dataset},
                        {"collections", new BsonArray { collection.Id }}
                    };

                    datasetCollection.InsertOne(datasetDocument);

                    // Convert object c# in BsonDocument
                    var bsonDocument = entity.ToBsonDocument();
                    _mongoCollection.InsertOne(bsonDocument);
                }
                else
                {
                    // Erro de coleção já existente
                    throw new System.Exception("Collection already exists");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }



    }
}
