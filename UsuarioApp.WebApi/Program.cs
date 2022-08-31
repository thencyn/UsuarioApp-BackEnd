using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;
using UsuarioApp.Repositorio;
using UsuarioApp.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServer<UsuarioApp.Modelo.UsuariosAppContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServicioRol, ServicioRol>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(options => {
    options.Version = "v0.0.1";
    options.Title = "App Usuario";
    options.Description = "EndPoints de la aplicacion";
});
builder.Services.AddAutoMapper(typeof(UsuarioApp.Repositorio.AutoMapper.AutoMapperProfiles).Assembly);

var app = builder.Build();

app.UseOpenApi(); // serve OpenAPI/Swagger documents
app.UseSwaggerUi3(); // serve Swagger UI
app.UseReDoc(); // serve ReDoc UI

// Configure the HTTP request pipeline.
app.UseMiddleware<UsuarioApp.WebApi.Excepciones.ExcepcionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
