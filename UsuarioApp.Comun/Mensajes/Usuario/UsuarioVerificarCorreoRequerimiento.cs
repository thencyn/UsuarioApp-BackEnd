using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioVerificarCorreoRequerimiento
    {
        public int? IdUsuario { get; set; }
        public string Correo { get; set; }
    }
}