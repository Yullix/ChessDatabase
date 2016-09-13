using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;
using ChessDatabase.Repositories;

namespace ChessDatabase.Services
{
    public class CategoryService : IService
    {
        public event EventHandler Updated;
        private CategoryRepository _categoryRepository;

        public CategoryService(RepositoryFactory repoFactory)
        {
            this._categoryRepository = repoFactory.GetCategoryRepository();
        }

        public void Add(string name, string description)
        {
            var newCategory = new Category()
            {
                name = name,
                description = description
            };

            _categoryRepository.Add(newCategory);
        }

        public Category Find(int Id)
        {
            return _categoryRepository.Find(Id);
        }

        public bool Remove(int Id)
        {
            return _categoryRepository.Remove(Id);
        }

        public IEnumerable<Category> All()
        {
            return _categoryRepository.All();
        }

        public void Edit(Category category)
        {
            _categoryRepository.Edit(category);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
