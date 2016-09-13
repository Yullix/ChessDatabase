using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Repositories;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    public class PlayerService : IService
    {
        public event EventHandler Updated;
        private PlayerRepository _playerRepository;

        public PlayerService(RepositoryFactory repoFactory)
        {
            this._playerRepository = repoFactory.GetPlayerRepository();
        }

        public void Add(string name, int rating)
        {
            if (name != "")
            {
                Player newPlayer = new Player()
                {
                    name = name,
                    rating = rating
                };
                _playerRepository.Add(newPlayer);

                UpdatedEventArgs eArgs = new UpdatedEventArgs()
                {
                    updateMessage = "Add"
                };

                OnUpdated(eArgs);
            }
            else
                throw new ArgumentException("You must enter a name to create a new player.");            
        }

        public bool Remove(int Id)
        {
            if(_playerRepository.Remove(Id))
            {
                UpdatedEventArgs eArgs = new UpdatedEventArgs()
                {
                    updateMessage = "Remove",
                    entityId = Id
                };

                OnUpdated(eArgs);
                return true;
            }
            return false;
        }

        public IEnumerable<Player> All()
        {
            return _playerRepository.All();
        }

        public IEnumerable<Player> ByRating(int rating)
        {
            Func<Player, bool> function = p => p.rating >= rating;

            return _playerRepository.ByFunc(function);
        }

        public void Edit(Player player)
        {
            _playerRepository.Edit(player);
        }

        public Player Find(int Id)
        {
            return _playerRepository.Find(Id);
        }

        public IEnumerable<Player> ByName(string text)
        {
            Func<Player, bool> function = p => p.name.Contains(text);

            return _playerRepository.ByFunc(function);
        }

        protected virtual void OnUpdated(EventArgs e)
        {
            Updated?.Invoke(this, e);
        }
    }
}
