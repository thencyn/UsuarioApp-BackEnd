using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.IServicios;
using UsuarioApp.WebApi.Extensiones;

namespace UsuarioApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(Roles ="Administrador")]
    [Authorize]
    public class RolController : Controller
    {
        private readonly IServicioRol _servicioRol;

        public RolController(IServicios.IServicioRol servicioRol)
        {
            this._servicioRol = servicioRol;
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> Grabar([FromBody]RolGrabarRequerimiento requerimiento)
        {
            return await this._servicioRol.Grabar(requerimiento);
        }

        [HttpGet("[action]")]
        // [Authorize(Policy = "PolicyPuedeConsultar")]
        public async Task<ObtenerRolListadoRespuesta> ObtenerRolesTodos()
        {
            var IdUsuario = User.Ext_ObtenerIdUsuario();
            var Nombre = User.Ext_ObtenerNombre();
            var Rol = User.Ext_ObtenerRol();
            var Correo = User.Ext_ObtenerCorreo();
            var IdRol = User.Ext_ObtenerIdRol();
            return await this._servicioRol.ObtenerRolesTodos();
        }
    }
}
