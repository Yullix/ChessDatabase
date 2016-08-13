using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class OpeningRepository : IRepository<Opening, int>
    {
        private ChessDatabaseContext context;

        public OpeningRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Opening item)
        {
            if (context.Openings.FirstOrDefault(o => o.name.Equals(item.name)) == null)
            {
                context.Openings.Add(item);
                context.SaveChanges();
            }
            else
                throw new DuplicateException("There is already an opening with this name in the database.");
        }

        public IEnumerable<Opening> All()
        {
            return context.Openings.ToList();
        }

        public IEnumerable<Opening> ByFunc(Func<Opening, bool> function)
        {
            return context.Openings.Where(function).ToList();
        }

        public void Edit(Opening item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Opening Find(int ID)
        {
            return context.Openings.FirstOrDefault(o => o.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Opening removeOpening = context.Openings.FirstOrDefault(o => o.Id.Equals(ID));

            if(removeOpening != null)
            {
                context.Openings.Remove(removeOpening);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
