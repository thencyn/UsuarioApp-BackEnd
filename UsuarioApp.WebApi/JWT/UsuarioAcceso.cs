using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.WebApi.JWT
{
    public class UsuarioAcceso
    {
        public string IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string IdRol { get; set; }
        public string Correo { get; set; }
    }
}