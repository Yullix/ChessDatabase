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
        private TournamentRepository tournamentRepository;

        public TournamentService(RepositoryFactory _repoFactory)
        {
            this.tournamentRepository = _repoFactory.GetTournamentRepository(); 
        }

        public void Add(string _name, DateTime _startDate, DateTime _endDate)
        {
            Tournament newTournament = new Tournament()
            {
                name = _name,
                startDate = _startDate,
                endDate = _endDate
            };
            tournamentRepository.Add(newTournament);
        }

        public IEnumerable<Tournament> All()
        {
            return tournamentRepository.All();
        }

        public void Edit(Tournament _tournament)
        {
            tournamentRepository.Edit(_tournament);
        }

        public Tournament Find(int _Id)
        {
            return tournamentRepository.Find(_Id);
        }

        public bool Remove(int _Id)
        {
            return tournamentRepository.Remove(_Id);
        }

        public IEnumerable<Tournament> ByTimeSpan(DateTime _startDate, DateTime _endDate)
        {
            Func<Tournament, bool> function = t => t.startDate > _startDate && t.endDate < _endDate;

            return tournamentRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
