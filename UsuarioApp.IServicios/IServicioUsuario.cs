using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Shared;
using UsuarioApp.Comun.Mensajes.Usuario;

namespace UsuarioApp.IServicios
{
    public interface IServicioUsuario
    {
        Task<BaseRespuesta> Agregar(UsuarioCrearRequerimiento requerimiento);
        Task<ObtenerUsuarioListadoRespuesta> ObtenerUsuariosTodos();
        Task<UsuarioDTO> Login(string usuario, string password);        
        Task<BaseRespuesta> Modificar(UsuarioModificarRequerimiento requerimiento);
        Task<BaseRespuesta> CambiarEstado(UsuarioCambiarEstadoRequerimiento requerimiento);
        Task<BaseRespuesta> CambiarPassword(UsuarioCambiarPasswordRequerimiento requerimiento);
        Task<UsuarioVerificarCorreoRespuesta> VerificarCorreo(UsuarioVerificarCorreoRequerimiento requerimiento);
        Task<ObtenerUsuarioRespuesta> ObtenerUsuarioPorId(ObtenerPorIdRequerimiento requerimiento);
    }
}
