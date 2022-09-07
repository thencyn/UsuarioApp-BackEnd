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
            return await this._servicioRol.ObtenerRolesTodos();
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> CambiarEstado([FromBody]RolCambiarEstadoRequerimiento requerimiento)
        {
            return await this._servicioRol.CambiarEstado(requerimiento);
        }

        [HttpGet("[action]")]
        public async Task<ObtenerRolPorIdRespuesta> ObtenerRolPorId([FromQuery]Comun.Mensajes.Shared.ObtenerPorIdRequerimiento requerimiento)
        {
            return await this._servicioRol.ObtenerRolPorId(requerimiento);
        }
    }
}
