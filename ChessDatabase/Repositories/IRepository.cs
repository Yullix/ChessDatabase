﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Repositories
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string _message) : base(_message)
        {

        }
    }

    public interface IRepository<T, Tid> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> All();
        bool Remove(Tid ID);
        T Find(Tid ID);
        void Edit(T item);
        IEnumerable<T> ByFunc(Func<T, bool> function);
    }
}
