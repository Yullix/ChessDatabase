using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Repositories
{
    public interface IRepository<T, Tid>
    {
        void Add(T item);
        void Remove(T item);
        T Find(Tid ID);
        void Edit(T item);
        IEnumerable<T> All();
    }
}
