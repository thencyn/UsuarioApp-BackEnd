using Microsoft.AspNetCore.Mvc;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.IServicios;
using UsuarioApp.Comun.Mensajes.Usuario;

namespace UsuarioApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IServicioUsuario servicioUsuario;

        public UsuarioController(IServicios.IServicioUsuario servicioUsuario)
        {
            this.servicioUsuario = servicioUsuario;
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> Grabar([FromBody] UsuarioCrearRequerimiento requerimiento)
        {
            return await this.servicioUsuario.Agregar(requerimiento);
        }

        [HttpGet("[action]")]
        public async Task<ObtenerUsuarioListadoRespuesta> ObtenerUsuariosTodos()
        {
            return await this.servicioUsuario.ObtenerUsuariosTodos();
        }

    }
}
