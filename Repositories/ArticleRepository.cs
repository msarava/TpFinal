using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<Article> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Article FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Article element)
        {
            throw new NotImplementedException();
        }
    }
}
