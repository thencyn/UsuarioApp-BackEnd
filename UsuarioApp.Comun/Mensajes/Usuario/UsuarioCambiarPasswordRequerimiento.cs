using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioCambiarPasswordRequerimiento
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El IdUsuario debe ser mayor a 1")]
        public int IdUsuario { get; set; }

        [MaxLength(12, ErrorMessage = "El largo máximo es de 12 caracteres")]
        [MinLength(6, ErrorMessage = "El largo mínimo es de 6 carácteres")]
        public string Password { get; set; }
    }
}