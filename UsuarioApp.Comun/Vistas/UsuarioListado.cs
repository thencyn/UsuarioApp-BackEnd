using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Vistas
{
    public class UsuarioListado
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool RegistroVigente { get; set; }

        public string Rol { get; set; }
    }
}
