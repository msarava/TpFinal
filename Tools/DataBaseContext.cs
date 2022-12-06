using LeBonCoin_Toulouse.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LeBonCoin_Toulouse.Tools
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<RoleApp> RolesApp { get; set; }
        public DbSet<UserApp> UsersApp { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:utopios-m2i.database.windows.net,1433;Initial Catalog=leboncoin_m2i_toulouse;Persist Security Info=False;User ID=m2iformation;Password=Toto.Tata12/;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
