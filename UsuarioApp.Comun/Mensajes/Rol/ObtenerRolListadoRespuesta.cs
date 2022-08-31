using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;

namespace UsuarioApp.Comun.Mensajes.Rol
{
    public class ObtenerRolListadoRespuesta : BaseRespuesta
    {
        public IEnumerable<RolDTO> ListaRoles { get; set; }
    }
}
