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
