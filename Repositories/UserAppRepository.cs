using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;
using Microsoft.EntityFrameworkCore;

namespace LeBonCoin_Toulouse.Repositories
{
    public class UserAppRepository : BaseRepository<UserApp>
    {
        public UserAppRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<UserApp> FindAll()
        {
            return _dataBaseContext.UsersApp.Include(p => p.RoleApp).ToList();
        }

        public override UserApp? FindById(int id)
        {
            return _dataBaseContext.UsersApp.Include(p => p.RoleApp).FirstOrDefault(p => p != null && p.Id == id);
        }

        public override bool Save(UserApp element)
        {
            _dataBaseContext.UsersApp.Add(element);
            return Update();
        }

        public UserApp SearchOne(Func<UserApp, bool> searchMethode)
        {
            return _dataBaseContext.UsersApp.Include(u => u.RoleApp).Where(searchMethode).First();
            /*return _dataBaseContext.UsersApp.FirstOrDefault(searchMethode);*/
        }

        public override bool Delete(UserApp element)
        {
            _dataBaseContext.UsersApp.Remove(element);
            return Update();
        }
    }
}
