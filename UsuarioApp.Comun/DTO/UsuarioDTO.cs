using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool RegistroVigente { get; set; }

        //public virtual Rol IdRolNavigation { get; set; }
    }
}
