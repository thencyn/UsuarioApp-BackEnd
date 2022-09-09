using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class ObtenerUsuarioRespuesta : BaseRespuesta
    {
        public UsuarioDTO Usuario { get; set; }
    }
}