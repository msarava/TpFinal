using LeBonCoin_Toulouse.Models;

namespace LeBonCoin_Toulouse.DTOs
{
    public class UserAppResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
    }
}
