using apiinventario.DataAccess;
using apiinventario.Repositorys;
using apiinventario.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//agregar modelado

//productos
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoService>();

//cliente
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

//ventas
builder.Services.AddScoped<ResumenVentasRepository>();
builder.Services.AddScoped<VentasService>();

//detalle
builder.Services.AddScoped<DetallleVentaRepository>();
builder.Services.AddScoped<VentaRepository>();

//hablitar cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

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

//hablitar all cors
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
