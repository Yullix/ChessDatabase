using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Repositories;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    public class MatchService : IService
    {
        public event EventHandler Updated;
        private MatchRepository matchRepository;
        private MoveRepository moveRepository;

        public MatchService(RepositoryFactory _repoFactory)
        {
            this.moveRepository = _repoFactory.GetMoveRepository();
            this.matchRepository = _repoFactory.GetMatchRepository();
        }

        public void Add(List<Ply> _plies, string _name, int _blackId, int _whiteId, DateTime _date, int? _categoryId)
        {
            var newMatch = new Match()
            {
                name = _name,
                blackPlayerId = _blackId,
                whitePlayerId = _whiteId,
                categoryId = _categoryId,
                date = _date,
                plies = _plies
            };

            matchRepository.Add(newMatch);

            OnUpdatedEventArgs eArgs = new OnUpdatedEventArgs()
            {
                updateMessage = "Add"
            };

            OnUpdated(eArgs);
        }

        public bool Remove(int _Id)
        {
            if(matchRepository.Remove(_Id))
            {
                OnUpdatedEventArgs eArgs = new OnUpdatedEventArgs()
                {
                    updateMessage = "Remove"
                };

                OnUpdated(eArgs);
                return true;
            }
            return false;
        }

        public IEnumerable<Match> All()
        {
            return matchRepository.All();
        }

        public IEnumerable<Match> ByPlayer(int _playerId)
        {
            Func<Match, bool> function = m => m.blackPlayerId.Equals(_playerId) || m.whitePlayerId.Equals(_playerId);

            return matchRepository.ByFunc(function);
        }

        public IEnumerable<Match> ByCategory(int _categoryId)
        {
            Func<Match, bool> function = m => m.categoryId.Equals(_categoryId);

            return matchRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }

    }
}
