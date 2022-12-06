using LeBonCoin_Toulouse.Services.Interfaces;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LeBonCoin_Toulouse.Services
{
    public class LoginJWTService : ILogin // legacy interface login 
    {
        private UserAppRepository _repository;

        public LoginJWTService(UserAppRepository repository) // add here => UserAppRepository repository 
        {
            _repository = repository;
        }

        public string Login(string mail, string password)
        {
            UserApp user = _repository.SearchOne(user => user.Email == mail && user.Password == password);
            if(user != null)
            {
                //Create token
                JwtSecurityTokenHandler jwtServiceTokenHandler = new JwtSecurityTokenHandler();
                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de sécurité pour générer la JWT")), SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.RoleApp.Role),
                    new Claim(ClaimTypes.Name, user.LastName)
                }),
                    Issuer = "sogeti",
                    Audience = "sogeti"
                };
                SecurityToken securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                return JwtSecurityTokenHandler.WriteToken(securityToken);
            }
            return null,
        }
    }
}
