using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;

namespace UsuarioApp.Comun.Mensajes.Rol
{
    public class ObtenerRolPorIdRespuesta : BaseRespuesta
    {
        public RolDTO Rol { get; set; }
    }
}