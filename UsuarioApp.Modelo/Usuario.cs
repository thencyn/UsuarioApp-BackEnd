﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace UsuarioApp.Modelo
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool RegistroVigente { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}