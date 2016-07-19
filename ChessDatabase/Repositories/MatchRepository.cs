using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class MatchRepository : IRepository<Match, int>
    {
        private ChessDatabaseContext context;

        public MatchRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Match item)
        {
            context.Matches.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Match> All()
        {
            var result = context.Matches.ToList();

            return result;
        }

        public IEnumerable<Match> ByFunc(Func<Match, bool> function)
        {
            var result = context.Matches.Where(function).ToList();

            return result;
        }

        public void Edit(Match item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Match Find(int ID)
        {
            return context.Matches.FirstOrDefault(m => m.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Match removeMatch = context.Matches.FirstOrDefault(m => m.Id.Equals(ID));

            if (removeMatch != null)
            {
                context.Matches.Remove(removeMatch);

                return true;
            }
            return false;
        }
    }
}
