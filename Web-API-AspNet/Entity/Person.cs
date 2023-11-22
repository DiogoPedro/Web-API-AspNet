using MongoDB.Bson.Serialization.Attributes;

namespace Web_API_AspNet.Entity
{
	public class Person : Base
	{
		[BsonElement("name")]
		public string Name { get; set; } = null!;

		[BsonElement("age")]
		public int Age { get; set; } 

		[BsonElement("address")]
		public string Address { get; set; } = null!;

		[BsonElement("city")]
		public string City { get; set; } = null!;

		[BsonElement("country")]
		public string Country { get; set; } = null!;
	}

}
