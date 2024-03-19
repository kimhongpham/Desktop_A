using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   // [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbConnect : DbContext
    {
        public DbSet<DALGames> DALGame { get; set; }
        public DbSet<DALUsers> DALUser { get; set; }

        public DbSet<DALUserGames> DALUserGame { get; set; }
        public DbSet<DALGameSessions> DALGameSession { get; set; }

        //Constructor nếu cần 
        public DbConnect(DbSet<DALGames> dALGame, DbSet<DALUsers> dALUser, DbSet<DALUserGames> dALUserGame, DbSet<DALGameSessions> dALGameSession)
        {
            DALGame = dALGame;
            DALUser = dALUser;
            DALUserGame = dALUserGame;
            DALGameSession = dALGameSession;
        }
    }
}