// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UsuarioApp.Modelo
{
    public partial class Rol
    {
        public Rol()
        {
            RolPantalla = new HashSet<RolPantalla>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool RegistroVigente { get; set; }

        public virtual ICollection<RolPantalla> RolPantalla { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}