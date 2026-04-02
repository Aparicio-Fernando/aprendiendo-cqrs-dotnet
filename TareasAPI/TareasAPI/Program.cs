using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
using TareasAPI.Handlers.Command;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar DbContext con SQL Server
builder.Services.AddDbContext<TareasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registrar MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CrearTareaHandler).Assembly));

var app = builder.Build();

app.UseHttpsRedirection();

// Mapea las rutas de los controladores
app.MapControllers();

// Crear y migrar la base de datos automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TareasDbContext>();
    db.Database.Migrate();
}

app.Run();
