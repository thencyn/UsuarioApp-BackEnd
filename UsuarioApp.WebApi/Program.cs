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

builder.Services.AddAutoMapper(typeof(UsuarioApp.Repositorio.AutoMapper.AutoMapperProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
