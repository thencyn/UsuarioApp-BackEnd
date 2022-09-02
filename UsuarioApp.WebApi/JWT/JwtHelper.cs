using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace UsuarioApp.WebApi.JWT
{
    public class JwtHelper
    {
        private readonly AuthSettings _authSettings;
        public JwtHelper(AuthSettings settings)
        {
            this._authSettings = settings;
        }

        public string GenerarTokenJwt(UsuarioAcceso usuario)
        {
            var secretKey = this._authSettings.SecretKey;
            var minutos = this._authSettings.Minutes;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(CreacionClaim(usuario)),
                Expires = DateTime.UtcNow.AddMinutes(minutos),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private List<Claim> CreacionClaim(UsuarioAcceso usuario)
        {
            List<Claim> listaClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim("IdRol", usuario.IdRol),
                // new Claim("PuedeConsultar", usuario.IdRol == "2" ? "S" : "N"),
            };

            return listaClaims;
        }
    }
}