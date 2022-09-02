using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;
using UsuarioApp.Repositorio;
using UsuarioApp.Servicios;

namespace UsuarioApp.WebApi.Extensiones
{
    public static class ServicesExtensiones
    {
        public static void AgregarServiciosAplicacion(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServicioRol, ServicioRol>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IServicioPantalla, ServicioPantalla>();
        }

        public static void AgregarSwagger(this IServiceCollection services)
        {
            services.AddOpenApiDocument(options =>
            {
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
        }

        public static void AgregarBaseDatos(this IServiceCollection services, IConfiguration config)
        {
            services.AddSqlServer<UsuarioApp.Modelo.UsuariosAppContext>(config.GetConnectionString("DefaultConnection"));
        }

        public static void AgregarJWT(this IServiceCollection services, IConfiguration config)
        {
            var configuracionAuth = config.GetSection("JWTSettings");
            services.Configure<UsuarioApp.WebApi.JWT.AuthSettings>(configuracionAuth);
            var appSettings = configuracionAuth.Get<UsuarioApp.WebApi.JWT.AuthSettings>();
            var key = Encoding.UTF8.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            services.AddSingleton(new UsuarioApp.WebApi.JWT.JwtHelper(appSettings));

        }
    }
}