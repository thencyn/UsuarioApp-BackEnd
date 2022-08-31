using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Comun.DTO
{
    public class PantallaDTO
    {
        public int IdPantalla { get; set; }
        public string Descripcion { get; set; }
        public string PathUrl { get; set; }
        public string Icono { get; set; }
        public int? IdPantallaPadre { get; set; }
        public int Orden { get; set; }
        public bool RegistroVigente { get; set; }

        //public virtual ICollection<RolPantalla> RolPantalla { get; set; }
    }
}
