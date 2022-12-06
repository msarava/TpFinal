using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public class UserAppRepository : BaseRepository<UserApp>
    {
        public UserAppRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
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

        public UserApp SearchOne(Func<UserApp, bool> searchMethode)
        {
            throw new NotImplementedException();
        }
    }
}
