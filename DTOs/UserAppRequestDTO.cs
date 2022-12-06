using Microsoft.Identity.Client;

namespace LeBonCoin_new.DTOs
{
    public class UserAppRequestDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleAppId { get; set; }
    }
}
