﻿using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Tools;

namespace LeBonCoin_Toulouse.Repositories
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<Image> FindAll()
        {
            throw new NotImplementedException();
        }

        public override Image FindById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Save(Image element)
        {
            throw new NotImplementedException();
        }
    }
}
