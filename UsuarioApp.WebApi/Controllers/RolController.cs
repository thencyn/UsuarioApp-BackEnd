using Microsoft.AspNetCore.Mvc;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.IServicios;

namespace UsuarioApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ObtenerRolListadoRespuesta> ObtenerRolesTodos()
        {
            return await this._servicioRol.ObtenerRolesTodos();
        }
    }
}
