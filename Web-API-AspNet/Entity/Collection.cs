using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_API_AspNet.Entity
{
    public class Collection : Base
    {
        [BsonElement("name_collection")]
        public string NameCollection { get; set; }
    }
}
