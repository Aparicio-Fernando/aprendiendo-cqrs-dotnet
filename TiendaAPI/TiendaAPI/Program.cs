using TiendaAPI.Commands.Productos;
using TiendaAPI.DTOs;
using TiendaAPI.Handlers.Commands;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;
using TiendaAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Registra los controladores
builder.Services.AddControllers();

// Una sola línea registra todos los Handlers automáticamente
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CrearProductoHandler).Assembly));

var app = builder.Build();

app.UseHttpsRedirection();
// Mapea las rutas de los controladores
app.MapControllers();
app.Run();