using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Repositories
{
    public interface IRepository<T, Tid>
    {
        void Add(T item);
        bool Remove(Tid ID);
        T Find(Tid ID);
        void Edit(T item);
        IEnumerable<T> ByFunc(Func<T, bool> function);
    }
}
