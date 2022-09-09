using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class UsuarioCambiarEstadoRequerimiento
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El IdUsuario debe ser mayor a 1")]
        public int IdUsuario { get; set; }
    }
}