using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web_API_AspNet.Entity;
using Web_API_AspNet.Settings;

namespace Web_API_AspNet.Services
{
	public class PersonService
	{
		private readonly IMongoCollection<Person> _personCollection;

		public PersonService(IOptions<PersonDataSettings> personService)
		{
			var mongoClient = new MongoClient(personService.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(personService.Value.DatabaseName);
			_personCollection = mongoDatabase.GetCollection<Person>(personService.Value.CollectionName);
		}

		public async Task<Person> CreateAsync(Person person)
		{
			try
			{
				await _personCollection.InsertOneAsync(person);
				return person;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<Person> ReadAsync(string id)
		{
			var filter = Builders<Person>.Filter.Eq(person => person.Name, id);
			return await _personCollection.Find(filter).FirstOrDefaultAsync();
		}

		public async Task<Person> UpdateAsync(string id, Person person)
		{
			var filter = Builders<Person>.Filter.Eq(person => person.Name, id);
			await _personCollection.ReplaceOneAsync(filter, person);
			return person;
		}

		public async Task<Person> DeleteAsync(string id)
		{
			var filter = Builders<Person>.Filter.Eq(person => person.Name, id);
			return await _personCollection.FindOneAndDeleteAsync(filter);
		}
	}
}
