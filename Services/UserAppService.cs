using Azure;
using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;
using System.Collections.Generic;

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
            UserApp userApp = new UserApp() { FirstName = userAppRequestDTO.FirstName, LastName = userAppRequestDTO.LastName, Email = userAppRequestDTO.Email, Password = userAppRequestDTO.Password, RoleAppId = userAppRequestDTO.RoleAppId, StatusUser = false};
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

        public UserAppResponseDTO UpdateUser(int id, UserAppRequestDTO userAppRequestDTO)
        {
            UserApp userApp = _userAppRepository.FindById(id);
            if (userApp != null)
            {
                userApp.RoleAppId = userAppRequestDTO.RoleAppId;
                if (_userAppRepository.Update())
                {
                    UserAppResponseDTO response = new UserAppResponseDTO();
                    response.FirstName = userApp.FirstName;
                    response.LastName = userApp.LastName;
                    response.Email = userApp.Email;
                    response.RoleAppId = userApp.RoleAppId;
                    return response;
                }
                throw new Exception("Modification erreur");
            }
            throw new Exception("Modification erreur");
        }

        public UserAppResponseDTO UpdateStatusUser(int id, bool status)
        {
            UserApp userApp = _userAppRepository.FindById(id);
            if (userApp != null)
            {
                userApp.StatusUser = status;
                if (_userAppRepository.Update())
                {
                    UserAppResponseDTO response = new UserAppResponseDTO();
                    response.FirstName = userApp.FirstName;
                    response.LastName = userApp.LastName;
                    response.Email = userApp.Email;
                    response.RoleAppId = userApp.RoleAppId;
                    return response;
                }
                throw new Exception("Modification status erreur");
            }
            throw new Exception("Modification status erreur");
        }

        public List<UserAppResponseDTO> GetAllUsers()
        {
            List<UserApp> usersAppList = _userAppRepository.FindAll();
            List<UserAppResponseDTO> usersAppListResponse = new List<UserAppResponseDTO>();
            if (usersAppList != null)
            {
                usersAppList.ForEach(ul =>
                {
                    usersAppListResponse.Add(new UserAppResponseDTO() { FirstName = ul.FirstName, LastName = ul.LastName, Email = ul.Email, RoleAppId = ul.RoleAppId});
                });
                return usersAppListResponse;
            }
            throw new Exception("Aucun utilisateur dans la bdd");
        }
    }
}
