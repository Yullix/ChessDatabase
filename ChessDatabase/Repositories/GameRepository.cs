using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

//Ted Torkkeli
// 2016-07-05

public class NotUniqueIdException : Exception
{
    int ID;

    public NotUniqueIdException(string message, int _ID) : base(message)
    {
        this.ID = _ID;
    }
}

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
            //if(context.Games.Where(g => g.Id.Equals(item.Id)).Count() > 0)
            //{
            //    throw new NotUniqueIdException("There is already a game with this ID in the database.", item.Id);
            //}

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
            context.Games.Remove(context.Games.FirstOrDefault(i => i.Id.Equals(item.Id)));
            context.Games.Add(item);
            context.SaveChanges();
        }

        public Game Find(int ID)
        {
            return context.Games.FirstOrDefault(i => i.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Game game = context.Games.FirstOrDefault(g => g.Id.Equals(ID));

            if (game != null)
            {
                foreach(var m in context.Moves.Where(i => i.GameId.Equals(ID)).ToList())
                {
                    context.Moves.Remove(m);
                }
                context.Games.Remove(context.Games.FirstOrDefault(i => i.Id.Equals(ID)));
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
