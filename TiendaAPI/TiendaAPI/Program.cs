using Microsoft.EntityFrameworkCore;
using TiendaAPI.Commands.Productos;
using TiendaAPI.Data;
using TiendaAPI.DTOs;
using TiendaAPI.Handlers.Commands;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;
using TiendaAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Registra los controladores
builder.Services.AddControllers();

// Registrar DbContext con SQL Server
builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CrearProductoHandler).Assembly));


var app = builder.Build();

app.UseHttpsRedirection();
// Mapea las rutas de los controladores
app.MapControllers();

// Crear y migrar la base de datos automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TiendaDbContext>();
    db.Database.Migrate();
}

app.Run();