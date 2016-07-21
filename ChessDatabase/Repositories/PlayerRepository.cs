using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class PlayerRepository : IRepository<Player, int>
    {
        private ChessDatabaseContext context;

        public PlayerRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Player item)
        {
            context.Players.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Player> All()
        {
            return context.Players.ToList() ?? new List<Player>();
        }

        public IEnumerable<Player> ByFunc(Func<Player, bool> function)
        {
            return context.Players.Where(function).ToList();
        }

        public void Edit(Player item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Player Find(int ID)
        {
            return context.Players.FirstOrDefault(p => p.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Player removePlayer = context.Players.FirstOrDefault(p => p.Id.Equals(ID));

            if(removePlayer != null)
            {
                context.Players.Remove(removePlayer);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
