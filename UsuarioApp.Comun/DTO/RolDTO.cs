using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.DTO
{
    public class RolDTO
    {
        public int? IdRol { get; set; }

        [MaxLength(30, ErrorMessage = "El largo máximo es de 30 caracteres")]
        [MinLength(3, ErrorMessage = "El largo mínimo es de 3 caracteres")]
        public string Nombre { get; set; }
        public bool RegistroVigente { get; set; }
    }
}
