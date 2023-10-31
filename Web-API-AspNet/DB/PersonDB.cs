using Microsoft.EntityFrameworkCore;
using Web_API_AspNet.Entity;

namespace Web_API_AspNet.DB
{
	public class PersonDB : DbContext
	{
		public PersonDB(DbContextOptions<PersonDB> options)
		: base(options) { }

		public DbSet<Person> Todos => Set<Person>();
	}
}
