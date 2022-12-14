using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected DataBaseContext _dataBaseContext;

        protected BaseRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public abstract bool Save(T element);
        public abstract T FindById(int id);
        public abstract List<T> FindAll();

        public bool Update()
        {
            return _dataBaseContext.SaveChanges() > 0;
        }
        public abstract bool Delete(T element);
    }
}
