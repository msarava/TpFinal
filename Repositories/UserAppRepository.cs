using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public class UserRepository : BaseRepository<UserApp>
    {
        public UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<UserApp> FindAll()
        {
            throw new NotImplementedException();
        }

        public override UserApp FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(UserApp element)
        {
            throw new NotImplementedException();
        }
    }
}
