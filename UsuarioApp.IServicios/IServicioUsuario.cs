using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Usuario;

namespace UsuarioApp.IServicios
{
    public interface IServicioUsuario
    {
        Task<BaseRespuesta> Agregar(UsuarioCrearRequerimiento requerimiento);
        Task<ObtenerUsuarioListadoRespuesta> ObtenerUsuariosTodos();
    }
}
