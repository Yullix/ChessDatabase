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
    public class MoveRepository : IRepository<Ply, int>
    {
        private ChessDatabaseContext context;

        public MoveRepository(ChessDatabaseContext ctx)
        {
            context = ctx;
        }

        public void Add(Ply item)
        {
            context.Moves.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Ply> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ply> ByFunc(Func<Ply, bool> function)
        {
            throw new NotImplementedException();
        }

        public void Edit(Ply item)
        {
            throw new NotImplementedException();
        }

        public Ply Find(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public void Remove(Ply item)
        {
            throw new NotImplementedException();
        }
    }
}
