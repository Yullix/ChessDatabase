﻿using System;
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

        public DbSet<Ply> Moves { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
