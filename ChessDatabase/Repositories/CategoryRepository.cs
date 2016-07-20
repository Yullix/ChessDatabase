using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Repositories
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private ChessDatabaseContext context;

        public CategoryRepository(ChessDatabaseContext ctx)
        {
            this.context = ctx;
        }

        public void Add(Category item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Category> All()
        {
            return context.Categories.ToList();
        }

        public IEnumerable<Category> ByFunc(Func<Category, bool> function)
        {
            return context.Categories.Where(function).ToList();
        }

        public void Edit(Category item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Category Find(int ID)
        {
            return context.Categories.FirstOrDefault(c => c.Id.Equals(ID));
        }

        public bool Remove(int ID)
        {
            Category removeCat = context.Categories.FirstOrDefault(c => c.Id.Equals(ID));

            if(removeCat != null)
            {
                context.Categories.Remove(removeCat);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
