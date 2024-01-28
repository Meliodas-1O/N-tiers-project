using JeBalance.API.InspectionFiscale;
using JeBalance.Domain;
using JeBalance.Infrastructure;
using JeBalance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInspectFiscaleApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(option =>
			option.UseSqlite(connectionString),
			contextLifetime: ServiceLifetime.Scoped,
			optionsLifetime: ServiceLifetime.Transient);
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
