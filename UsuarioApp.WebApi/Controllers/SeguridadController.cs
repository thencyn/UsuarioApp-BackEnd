using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsuarioApp.IServicios;
using UsuarioApp.WebApi.JWT;

namespace UsuarioApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SeguridadController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;
        private readonly JwtHelper _jwtHelper;
        private readonly IServicioPantalla _servicioPantalla;

        public SeguridadController(IServicios.IServicioUsuario servicioUsuario, JWT.JwtHelper jwtHelper, IServicios.IServicioPantalla servicioPantalla)
        {
            this._servicioUsuario = servicioUsuario;
            this._jwtHelper = jwtHelper;
            this._servicioPantalla = servicioPantalla;
        }


        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<JWT.LoginRespuesta>> IniciarSesion([FromBody]CredencialesLogin credencialesLogin)
        {
            var loginRespuesta = await this._servicioUsuario.Login(credencialesLogin.NombreUsuario, credencialesLogin.Password);
            if (loginRespuesta != null)
            {
                var usuarioAcceso = new UsuarioAcceso()
                {
                    IdUsuario = loginRespuesta.IdUsuario.ToString(),
                    NombreUsuario = loginRespuesta.Correo,
                    Nombre = loginRespuesta.Nombre,
                    Rol = loginRespuesta.IdRolNavigation.Nombre,
                    IdRol = loginRespuesta.IdRol.ToString(),
                    Correo = loginRespuesta.Correo,
                };

                var token = this._jwtHelper.GenerarTokenJwt(usuarioAcceso);
                var listaPantallas = await this._servicioPantalla.ObtenerPantallasPorIdRol(new Comun.Mensajes.Shared.ObtenerPorIdRequerimiento() { Id = loginRespuesta.IdRol });
                return Ok(new JWT.LoginRespuesta { Token = token, MenuUsuario = listaPantallas });
            }
            return Unauthorized();
        }
    }
}