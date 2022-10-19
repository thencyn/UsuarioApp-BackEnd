using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.Mensajes.Rol
{
    public class RolPantallasGrabarRequerimiento
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El IdRol debe ser mayor a 1")]
        public int IdRol { get; set; }
        
        [Required]
        public List<int> ListaPantallas { get; set; }
    }
}