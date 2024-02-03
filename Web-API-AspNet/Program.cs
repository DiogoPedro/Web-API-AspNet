using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web_API_AspNet.DB;
using Web_API_AspNet.Services;
using Web_API_AspNet.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDataSettings>(builder.Configuration.GetSection("MongoDBLocal"));
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var mongoSettings = sp.GetRequiredService<IOptions<MongoDataSettings>>().Value;
    return new MongoClient(mongoSettings.ConnectionString);
});
builder.Services.AddSingleton<PersonService>();


builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var mongoClient = sp.GetRequiredService<IMongoClient>();
    var mongoSettings = sp.GetRequiredService<IOptions<MongoDataSettings>>().Value;
    return mongoClient.GetDatabase(mongoSettings.DatabaseName);
});

builder.Services.AddSingleton<CollectionService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<PersonDB>(opt => opt.UseInMemoryDatabase("PersonDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
