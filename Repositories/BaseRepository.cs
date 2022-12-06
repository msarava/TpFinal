namespace LeBonCoin_Toulouse.Repositories
{
    public class BaseRepository<T>
    {
        protected DataBaseContext _dataBaseContext;

    /*    protected BaseRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }*/

        //coucou 

        public abstract bool Save(T element);
        public abstract T FindById(int id);
        public abstract List<T> FindAll();

        public bool Update()
        {
            return _dataBaseContext.SaveChanges() > 0;
        }
    }
}
