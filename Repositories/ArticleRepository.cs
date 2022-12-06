using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;
using Microsoft.EntityFrameworkCore;

namespace LeBonCoin_Toulouse.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override bool Delete(Article element)
        {
            _dataBaseContext.Articles.Remove(element);
            return Update();
        }

        public override List<Article> FindAll()
        {
            return _dataBaseContext.Articles.Include(art => art.Comments).ToList();

        }

        public override Article FindById(int id)
        {
            return _dataBaseContext.Articles.Include(art => art.Comments).FirstOrDefault(art => art != null && art.Id == id);
        }

        public override bool Save(Article element)

        {
            _dataBaseContext.Articles.Add(element);
            return Update();
        }
    }
}
