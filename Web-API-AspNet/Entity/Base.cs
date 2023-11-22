using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Web_API_AspNet.Entity
{
	public class Base
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		[BsonElement("created_by")]
		public string Created_by { get; set; } = null;

		[BsonElement("modified_by")]
		public string Modified_by { get; set; } = null;

		[BsonElement("created_at")]
		public DateTime Created_at { get; set; } = DateTime.Now;

		[BsonElement("updated_at")]
		public DateTime Updated_at { get; set; } = DateTime.Now;
	}
}
