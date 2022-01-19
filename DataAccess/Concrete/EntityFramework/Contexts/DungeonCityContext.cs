using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DungeonCityContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string V = @"user id=b3273033ec8f1b;server=eu-cdbr-west-02.cleardb.net;database=heroku_05839907bdaedcb;password=23b7a0b5";
            //const string V = @"server=localhost;user=root;database=dungeoncity;password=root123";
            optionsBuilder.UseMySql(V, new MySqlServerVersion(new Version(8,0,27)));
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<UserItem> UserItem { get; set; }
        public DbSet<Core.Entities.Concrete.Attribute> Attribute { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<ItemAttribute> ItemAttribute { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

    }
}
