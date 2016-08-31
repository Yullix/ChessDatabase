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
        private OpeningRepository openingRepository;

        public OpeningService(RepositoryFactory _repoFactory)
        {
            this.openingRepository = _repoFactory.GetOpeningRepositry();
        }

        public void Add(List<Ply> _plies, string _name, string _openingMove)
        {
            if (_name != "")
            {
                var newOpening = new Opening()
                {
                    name = _name,
                    openingMove = _openingMove,
                    plies = _plies
                };

                openingRepository.Add(newOpening);
                OnUpdated(new UpdatedEventArgs() { updateMessage = "Add" });
            }
            else
                throw new ArgumentException("You must enter a name.");
               
        }

        public bool Remove(int _Id)
        {
            return openingRepository.Remove(_Id);
        }

        public IEnumerable<Opening> All()
        {
            return openingRepository.All();
        }

        public IEnumerable<Opening> ByOpeningMove(string _openingMove)
        {
            Func<Opening, bool> function = o => o.openingMove.Equals(_openingMove);

            return openingRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
