using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;
using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;
using UsuarioApp.Repositorio;
using UsuarioApp.Servicios;
using UsuarioApp.WebApi.Extensiones;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AgregarServiciosAplicacion();
builder.Services.AgregarBaseDatos(builder.Configuration);
builder.Services.AgregarJWT(builder.Configuration);
builder.Services.AgregarSwagger();
builder.Services.AddAutoMapper(typeof(UsuarioApp.Repositorio.AutoMapper.AutoMapperProfiles).Assembly);

builder.Services.AddCors(o => o.AddPolicy("AddCors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(); // serve OpenAPI/Swagger documents
    app.UseSwaggerUi3(); // serve Swagger UI
    app.UseReDoc(); // serve ReDoc UI    
}

// Configure the HTTP request pipeline.
app.UseCors("AddCors");
app.UseMiddleware<UsuarioApp.WebApi.Excepciones.ExcepcionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
