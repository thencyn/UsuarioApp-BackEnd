using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioVerificarCorreoRespuesta : BaseRespuesta
    {
        public bool ExisteCorreo { get; set; }
    }
}