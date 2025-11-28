using apiinventario.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//conecctions DB
const string ConnectionApiInventario = "ApiInventario";
var connectionSringInventario = builder.Configuration.GetConnectionString(ConnectionApiInventario);

//Contexto DB
builder.Services.AddDbContext<ApiInventarioContext>(options=>options.UseSqlServer(connectionSringInventario));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
