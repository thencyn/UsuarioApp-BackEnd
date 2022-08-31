using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Rol;

namespace UsuarioApp.IRepositorio
{
    public interface IRolRepositorio
    {
        Task<IEnumerable<RolDTO>> ObtenerRolesTodos();
        Task Grabar(RolGrabarRequerimiento requerimiento);
    }
}
