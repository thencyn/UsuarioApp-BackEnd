using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UsuarioApp.WebApi.Extensiones
{
    public static class ClaimsExtensiones
    {
        public static string Ext_ObtenerIdUsuario(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string Ext_ObtenerNombre(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static string Ext_ObtenerRol(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Role)?.Value;
        }

        public static string Ext_ObtenerCorreo(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public static string Ext_ObtenerIdRol(this ClaimsPrincipal user)
        {
            return user.FindFirst("IdRol")?.Value;
        }
        
    }
}