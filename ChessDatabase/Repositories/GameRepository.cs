using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class GameRepository : IRepository<Game, int>
    {
        public void Add(Game item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(Game item)
        {
            throw new NotImplementedException();
        }

        public Game Find(int ID)
        {
            throw new NotImplementedException();
        }

        public void Remove(Game item)
        {
            throw new NotImplementedException();
        }
    }
}
