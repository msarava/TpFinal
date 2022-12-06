using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<Comment> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Comment FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Comment element)
        {
            throw new NotImplementedException();
        }
    }
}
