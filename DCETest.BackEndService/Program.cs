using DCETest.DataAccessService.Customer;
using DCETest.DataAccessService.Customer.Interface;
using DCETest.DataAccessService.SqlDataService;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//GetConnectionString
var configuration = new ConfigurationBuilder()
 .AddJsonFile("appsettings.json")
 .Build();

AppSettings.ConnectionString = configuration.GetConnectionString("DConnectionString");



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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
