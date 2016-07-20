using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class TournamentRepository : IRepository<Tournament, int>
    {
        private ChessDatabaseContext context;

        public TournamentRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Tournament item)
        {
            context.Tournaments.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Tournament> All()
        {
            return context.Tournaments.ToList();
        }

        public IEnumerable<Tournament> ByFunc(Func<Tournament, bool> function)
        {
            return context.Tournaments.Where(function).ToList();
        }

        public void Edit(Tournament item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Tournament Find(int ID)
        {
            return context.Tournaments.FirstOrDefault(t => t.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Tournament removeTournament = context.Tournaments.FirstOrDefault(t => t.Id.Equals(ID));

            if(removeTournament != null)
            {
                context.Tournaments.Remove(removeTournament);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
