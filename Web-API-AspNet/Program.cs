using Microsoft.EntityFrameworkCore;
using Web_API_AspNet.DB;
using Web_API_AspNet.Services;
using Web_API_AspNet.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<PersonDataSettings>(builder.Configuration.GetSection("MongoDBLocalPerson"));
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
