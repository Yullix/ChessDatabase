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
        private MatchRepository _matchRepository;
        private MoveRepository _moveRepository;

        public MatchService(RepositoryFactory repoFactory)
        {
            this._moveRepository = repoFactory.GetMoveRepository();
            this._matchRepository = repoFactory.GetMatchRepository();
        }

        public void Add(List<Ply> plies, string name, int blackId, int whiteId, DateTime date, int? categoryId)
        {
            var newMatch = new Match()
            {
                name = name,
                blackPlayerId = blackId,
                whitePlayerId = whiteId,
                categoryId = categoryId,
                date = date,
                plies = plies
            };

            _matchRepository.Add(newMatch);

            UpdatedEventArgs eArgs = new UpdatedEventArgs()
            {
                updateMessage = "Add"
            };

            OnUpdated(eArgs);
        }

        public bool Remove(int Id)
        {
            if(_matchRepository.Remove(Id))
            {
                UpdatedEventArgs eArgs = new UpdatedEventArgs()
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
            return _matchRepository.All();
        }

        public IEnumerable<Match> ByPlayer(int playerId)
        {
            Func<Match, bool> function = m => m.blackPlayerId.Equals(playerId) || m.whitePlayerId.Equals(playerId);

            return _matchRepository.ByFunc(function);
        }

        public IEnumerable<Match> ByCategory(int categoryId)
        {
            Func<Match, bool> function = m => m.categoryId.Equals(categoryId);

            return _matchRepository.ByFunc(function);
        }

        public IEnumerable<Ply> GetPlies(int matchId)
        {
            return _matchRepository.GetPlies(matchId);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }

    }
}
