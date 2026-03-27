using TiendaAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

// Registra los controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Mapea las rutas de los controladores
app.MapControllers();

app.Run();