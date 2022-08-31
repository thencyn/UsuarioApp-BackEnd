using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.DTO
{
    public class RolDTO
    {
        public int? IdRol { get; set; }
        public string Nombre { get; set; }
        public bool RegistroVigente { get; set; }
    }
}
