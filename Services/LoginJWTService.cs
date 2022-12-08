using LeBonCoin_Toulouse.Services.Interfaces;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LeBonCoin_Toulouse.DTOs;

namespace LeBonCoin_Toulouse.Services;

public class LoginJwtService : ILogin
{
    private UserAppRepository _repository;

    public LoginJwtService(UserAppRepository repository)
    {
        _repository = repository;
    }
    public LoginResponseDTO Login(string email, string password)
    {
        UserApp user = _repository.SearchOne(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            //Créer le token 
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de sécurité pour générer la JWT")), SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.RoleApp.Role),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Issuer = "sogeti",
                Audience = "sogeti"

            };
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            LoginResponseDTO response = new LoginResponseDTO()
            {
                Id = user.Id,
                Token = jwtSecurityTokenHandler.WriteToken(securityToken),
                StatusUser = user.StatusUser
            };
            return response;
        }
        throw new Exception() ;
    }
}
