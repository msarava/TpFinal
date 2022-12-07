using LeBonCoin_Toulouse.DTOs;

namespace LeBonCoin_Toulouse.Services.Interfaces
{
    public interface ILogin
    {
        // add interface for login with JWT
        public LoginResponseDTO Login(string mail, string password);
    }
}
