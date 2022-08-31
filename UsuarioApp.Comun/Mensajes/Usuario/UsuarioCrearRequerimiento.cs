using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioCrearRequerimiento
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
