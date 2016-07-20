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
        private CategoryRepository categoryRepository;

        public CategoryService(RepositoryFactory _repoFactory)
        {
            this.categoryRepository = _repoFactory.GetCategoryRepository();
        }

        public void Add(string _name, string _description)
        {
            var newCategory = new Category()
            {
                name = _name,
                description = _description
            };

            categoryRepository.Add(newCategory);
        }

        public Category Find(int _Id)
        {
            return categoryRepository.Find(_Id);
        }

        public bool Remove(int _Id)
        {
            return categoryRepository.Remove(_Id);
        }

        public IEnumerable<Category> All()
        {
            return categoryRepository.All();
        }

        public void Edit(Category _category)
        {
            categoryRepository.Edit(_category);
        }
    }
}
