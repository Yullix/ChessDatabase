using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;
using ChessDatabase.Repositories;

namespace ChessDatabase.Services
{
    public class TournamentService : IService
    {
        public event EventHandler Updated;
        private TournamentRepository _tournamentRepository;

        public TournamentService(RepositoryFactory repoFactory)
        {
            this._tournamentRepository = repoFactory.GetTournamentRepository(); 
        }

        public void Add(string name, DateTime startDate, DateTime endDate)
        {
            Tournament newTournament = new Tournament()
            {
                name = name,
                startDate = startDate,
                endDate = endDate
            };
            _tournamentRepository.Add(newTournament);
        }

        public IEnumerable<Tournament> All()
        {
            return _tournamentRepository.All();
        }

        public void Edit(Tournament tournament)
        {
            _tournamentRepository.Edit(tournament);
        }

        public Tournament Find(int Id)
        {
            return _tournamentRepository.Find(Id);
        }

        public bool Remove(int Id)
        {
            return _tournamentRepository.Remove(Id);
        }

        public IEnumerable<Tournament> ByTimeSpan(DateTime startDate, DateTime endDate)
        {
            Func<Tournament, bool> function = t => t.startDate > startDate && t.endDate < endDate;

            return _tournamentRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
