using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;
using Microsoft.EntityFrameworkCore;

namespace LeBonCoin_Toulouse.Repositories
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<Comment> FindAll()
        {
            return _dataBaseContext.Comments.ToList();
        }

        public override Comment FindById(int id)
        {
            return _dataBaseContext.Comments.FirstOrDefault(c => c != null && c.Id == id);
        }

        public override bool Save(Comment element)
        {
            _dataBaseContext.Comments.Add(element);
            return Update();
        }
    }
}
