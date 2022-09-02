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

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddSqlServer<UsuarioApp.Modelo.UsuariosAppContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServicioRol, ServicioRol>();
builder.Services.AddScoped<IServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IServicioPantalla, ServicioPantalla>();
builder.Services.AddControllers();

var configuracionAuth = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<UsuarioApp.WebApi.JWT.AuthSettings>(configuracionAuth);
var appSettings = configuracionAuth.Get<UsuarioApp.WebApi.JWT.AuthSettings>();
var key = Encoding.UTF8.GetBytes(appSettings.SecretKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
// builder.Services.AddAuthorization(options => {
//     options.AddPolicy("PolicyPuedeConsultar", policy => policy.RequireClaim("PuedeConsultar", "S"));
// });
builder.Services.AddSingleton(new UsuarioApp.WebApi.JWT.JwtHelper(appSettings));


builder.Services.AddOpenApiDocument(options => {
    options.Version = "v0.0.1";
    options.Title = "App Usuario";
    options.Description = "EndPoints de la aplicacion";
    options.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                options.DocumentProcessors.Add(
                    new SecurityDefinitionAppender(
                        "JWT",
                        new OpenApiSecurityScheme
                        {
                            Type = OpenApiSecuritySchemeType.ApiKey,
                            Name = "Authorization",
                            Description = "Copiar 'Bearer ' + JWT token valido",
                            In = OpenApiSecurityApiKeyLocation.Header
                        }
                    )
                );
});


builder.Services.AddAutoMapper(typeof(UsuarioApp.Repositorio.AutoMapper.AutoMapperProfiles).Assembly);

var app = builder.Build();

app.UseOpenApi(); // serve OpenAPI/Swagger documents
app.UseSwaggerUi3(); // serve Swagger UI
app.UseReDoc(); // serve ReDoc UI

// Configure the HTTP request pipeline.
app.UseMiddleware<UsuarioApp.WebApi.Excepciones.ExcepcionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
