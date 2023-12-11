using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web_API_AspNet.Entity;
using Web_API_AspNet.Settings;

namespace Web_API_AspNet.Services
{
	public class PersonService : BaseService<Person>
	{
		private readonly IMongoCollection<Person> _personCollection;

		public PersonService(IMongoClient mongoClient, IOptions<MongoDataSettings> mongoSettings) : 
			base(mongoClient, mongoSettings.Value.CollectionName, mongoSettings.Value.DatabaseName)
		{
			var mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
			_personCollection = mongoDatabase.GetCollection<Person>(mongoSettings.Value.CollectionName);
		}

		
	}
}
