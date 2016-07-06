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
    public class GameRepository : IRepository<Game, int>
    {
        private ChessDatabaseContext context;

        public GameRepository(ChessDatabaseContext ctx)
        {
            context = ctx;
        }

        public void Add(Game item)
        {
            context.Games.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Game> All()
        {
            var result = context.Games.ToList();

            return result;
        }

        public IEnumerable<Game> ByFunc(Func<Game, bool> function)
        {
            var result = context.Games.Where(function).ToList();

            return result;
        }

        public void Edit(Game item)
        {
            context.Games.Remove(context.Games.FirstOrDefault(i => i.GameID.Equals(item.GameID)));
            context.Games.Add(item);
            context.SaveChanges();
        }

        public Game Find(int ID)
        {
            return context.Games.FirstOrDefault(i => i.GameID.Equals(ID));
        }

        public bool Remove(int ID)
        {
            if (context.Games.Where(i => i.GameID.Equals(ID)).Count() > 0)
            {
                context.Games.Remove(context.Games.FirstOrDefault(i => i.GameID.Equals(ID)));
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
