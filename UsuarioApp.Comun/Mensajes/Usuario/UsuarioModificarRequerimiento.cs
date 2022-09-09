using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioModificarRequerimiento
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El IdUsuario debe ser mayor a 1")]
        public int IdUsuario { get; set; }

        [EmailAddress(ErrorMessage = "El email no es valido")]
        public string Correo { get; set; }

        [MaxLength(30, ErrorMessage = "El largo máximo es de 30 caracteres")]
        [MinLength(3, ErrorMessage = "El largo mínimo es de 3 carácteres")]
        public string Nombre { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El IdRol debe ser mayor a 1")]
        public int IdRol { get; set; }
    }
}