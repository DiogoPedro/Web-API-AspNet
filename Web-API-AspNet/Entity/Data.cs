using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_API_AspNet.Entity
{
    public class Data : Base
    {
        //[BsonExtraElements]
        //public BsonDocument Values { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
