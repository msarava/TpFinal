using Azure;
using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;

namespace LeBonCoin_Toulouse.Services
{
    public class UserAppService
    {
        private UserAppRepository _userAppRepository;

        public UserAppService(UserAppRepository userAppRepository)
        {
            _userAppRepository = userAppRepository;
        }

        public UserAppResponseDTO AddUser(UserAppRequestDTO userAppRequestDTO)
        {
            UserApp userApp = new UserApp() { FirstName = userAppRequestDTO.FirstName, LastName = userAppRequestDTO.LastName, Email = userAppRequestDTO.Email, Password = userAppRequestDTO.Password, RoleAppId = userAppRequestDTO.RoleAppId};
            if (_userAppRepository.Save(userApp))
            {
                return new UserAppResponseDTO() { FirstName = userApp.FirstName, LastName = userApp.LastName, Email = userApp.Email, RoleAppId = userApp.RoleAppId};
            }
            throw new Exception("Erreur serveur de base de données");
        }

        public UserAppResponseDTO GetById(int id)
        {
            UserApp userApp = _userAppRepository.FindById(id);
            if (userApp != null)
            {
                UserAppResponseDTO response = new UserAppResponseDTO() { FirstName = userApp.FirstName, LastName = userApp.LastName, Email = userApp.Email, RoleAppId = userApp.RoleAppId};
                return response;
            }
            throw new Exception("Aucun utilisateur avec cet id");
        }
    }
}
