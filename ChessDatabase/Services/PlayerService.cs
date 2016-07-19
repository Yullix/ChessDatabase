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
        private PlayerRepository playerRepository;

        public PlayerService(RepositoryFactory _repoFactory)
        {
            this.playerRepository = _repoFactory.GetPlayerRepository();
        }

        public void Add(string _name, int _rating)
        {
            Player newPlayer = new Player()
            {
                name = _name,
                rating = _rating
            };

            playerRepository.Add(newPlayer);
        }

        public bool Remove(int _Id)
        {
            return playerRepository.Remove(_Id);
        }

        public IEnumerable<Player> All()
        {
            return playerRepository.All();
        }

        public IEnumerable<Player> ByRating(int _rating)
        {
            Func<Player, bool> function = p => p.rating >= _rating;

            return playerRepository.ByFunc(function);
        }

        public void Edit(Player _player)
        {
            playerRepository.Edit(_player);
        }

        public Player Find(int _Id)
        {
            return playerRepository.Find(_Id);
        }

        public IEnumerable<Player> ByName(string _text)
        {
            Func<Player, bool> function = p => p.name.Contains(_text);

            return playerRepository.ByFunc(function);
        }
    }
}
