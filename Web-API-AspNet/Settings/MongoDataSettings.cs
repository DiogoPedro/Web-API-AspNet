namespace Web_API_AspNet.Settings
{
	public class MongoDataSettings
	{
		public string ConnectionString { get; set; } = null!;
		public string DatabaseName { get; set; } = null!;
		public string CollectionName { get; set; } = null!;
	}
}
