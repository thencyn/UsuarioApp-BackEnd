using Microsoft.AspNetCore.Mvc;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.IServicios;
using UsuarioApp.Comun.Mensajes.Usuario;
using Microsoft.AspNetCore.Authorization;
using UsuarioApp.Comun.Mensajes.Shared;

namespace UsuarioApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IServicioUsuario _servicioUsuario;

        public UsuarioController(IServicios.IServicioUsuario servicioUsuario)
        {
            this._servicioUsuario = servicioUsuario;
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> Grabar([FromBody] UsuarioCrearRequerimiento requerimiento)
        {
            return await this._servicioUsuario.Agregar(requerimiento);
        }

        [HttpGet("[action]")]
        public async Task<ObtenerUsuarioListadoRespuesta> ObtenerUsuariosTodos()
        {
            return await this._servicioUsuario.ObtenerUsuariosTodos();
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> Modificar([FromBody] UsuarioModificarRequerimiento requerimiento)
        {
            return await this._servicioUsuario.Modificar(requerimiento);
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> CambiarPassword([FromBody] UsuarioCambiarPasswordRequerimiento requerimiento)
        {
            return await this._servicioUsuario.CambiarPassword(requerimiento);
        }

        [HttpPost("[action]")]
        public async Task<BaseRespuesta> CambiarEstado([FromBody] UsuarioCambiarEstadoRequerimiento requerimiento)
        {
            return await this._servicioUsuario.CambiarEstado(requerimiento);
        }

        [HttpGet("[action]")]
        public async Task<ObtenerUsuarioRespuesta> ObtenerUsuarioPorId([FromQuery] ObtenerPorIdRequerimiento requerimiento)
        {
            return await this._servicioUsuario.ObtenerUsuarioPorId(requerimiento);
        }

        [HttpGet("[action]")]
        public async Task<UsuarioVerificarCorreoRespuesta> VerificarCorreo([FromQuery] UsuarioVerificarCorreoRequerimiento requerimiento)
        {
            return await this._servicioUsuario.VerificarCorreo(requerimiento);
        }

    }
}
