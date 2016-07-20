using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Models
{
    public class ChessDatabaseContext : DbContext
    {
        //public ChessDatabaseContext()
        //    : base("name=ChessDatabaseContext")
        //{

        //}

        public DbSet<Ply> Plies { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
