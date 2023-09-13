using PortalEstudiantil.EntidadesDeNegocio;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalEstudiantil.WebAPI.Auth
{
    public class JwtAuthenticationServices : IJwtAuthenticationServices
    {
        //inyección de dependencias de la llave de autenticación
        private readonly string _key;
        public JwtAuthenticationServices(string key)
        {
            _key = key;
        }

        public string Authenticate(Docente pDocente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, pDocente.Clave)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
