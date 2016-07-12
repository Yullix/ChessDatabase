using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Repositories
{
    public class MoveRepository : IRepository<Move, int>
    {
        private ChessDatabaseContext context;

        public MoveRepository(ChessDatabaseContext ctx)
        {
            context = ctx;
        }

        public void Add(Move item)
        {
            context.Moves.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Move> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Move> ByFunc(Func<Move, bool> function)
        {
            throw new NotImplementedException();
        }

        public void Edit(Move item)
        {
            throw new NotImplementedException();
        }

        public Move Find(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public void Remove(Move item)
        {
            throw new NotImplementedException();
        }
    }
}
