using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    class CategoryService : IService
    {
        public event EventHandler Updated;

        public void Add(string _name, string _description)
        {
            var newCategory = new Category()
            {
                name = _name,
                description = _description
            };
        }

        public bool Find(int _Id)
        {
            return true;
        }

        public bool Remove(int _Id)
        {
            return true;
        }

        public IEnumerable<Category> All()
        {
            return new List<Category>();
        }

        public void Update(Category _category)
        {

        }
    }
}
