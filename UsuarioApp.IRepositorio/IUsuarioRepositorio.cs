using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Usuario;
using UsuarioApp.Comun.Vistas;

namespace UsuarioApp.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Task Agregar(UsuarioCrearRequerimiento requerimiento);
        Task<IEnumerable<UsuarioListado>> ObtenerUsuariosTodos();
        Task<UsuarioDTO> Login(string usuario, string password);

        Task Modificar(UsuarioModificarRequerimiento requerimiento);
        Task CambiarEstado(UsuarioCambiarEstadoRequerimiento requerimiento);
        Task CambiarPassword(UsuarioCambiarPasswordRequerimiento requerimiento);
        Task<bool> VerificarPassword(UsuarioCambiarPasswordRequerimiento requerimiento);
        Task<bool> VerificarCorreo(UsuarioVerificarCorreoRequerimiento requerimiento);
        Task<UsuarioDTO> ObtenerUsuarioPorId(Comun.Mensajes.Shared.ObtenerPorIdRequerimiento requerimiento);
        Task<UsuarioDTO> ObtenerUsuarioPorCorreo(ObtenerUsuarioPorCorreoRequerimiento requerimiento);
    }
}
