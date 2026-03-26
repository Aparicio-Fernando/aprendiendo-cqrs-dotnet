var builder = WebApplication.CreateBuilder(args);

// Registra los controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Mapea las rutas de los controladores
app.MapControllers();

app.Run();