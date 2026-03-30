using TiendaAPI.Commands.Productos;
using TiendaAPI.Handlers.Commands;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;
using TiendaAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

builder.Services.AddScoped<ICommandHandler<CrearProductoCommand>, CrearProductoHandler>();
builder.Services.AddScoped<IQueryHandler<ObtenerProductosQuery, List<string>>, ObtenerProductosHandler>();


// Registra los controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Mapea las rutas de los controladores
app.MapControllers();

app.Run();