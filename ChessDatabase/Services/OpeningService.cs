using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Repositories;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    public class OpeningService : IService
    {
        public event EventHandler Updated;
        private OpeningRepository _openingRepository;

        public OpeningService(RepositoryFactory repoFactory)
        {
            this._openingRepository = repoFactory.GetOpeningRepositry();
        }

        public void Add(List<Ply> plies, string name, string openingMove)
        {
            if (name != "")
            {
                var newOpening = new Opening()
                {
                    name = name,
                    openingMove = openingMove,
                    plies = plies
                };

                _openingRepository.Add(newOpening);
                OnUpdated(new UpdatedEventArgs() { updateMessage = "Add" });
            }
            else
                throw new ArgumentException("You must enter a name.");
               
        }

        public bool Remove(int Id)
        {
            return _openingRepository.Remove(Id);
        }

        public IEnumerable<Opening> All()
        {
            return _openingRepository.All();
        }

        public IEnumerable<Opening> ByOpeningMove(string openingMove)
        {
            Func<Opening, bool> function = o => o.openingMove.Equals(openingMove);

            return _openingRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
