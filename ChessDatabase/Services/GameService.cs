using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;
using ChessDatabase.Repositories;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Services
{
    public class GameService : IService
    {
        public event EventHandler Updated;
        private GameRepository gameRepository;
        private MoveRepository moveRepository;
        
        public GameService(RepositoryFactory _repoFactory)
        {
            gameRepository = _repoFactory.GetGameRepository();
            moveRepository = _repoFactory.GetMoveRepository();
        }

        public void Add(List<Move> _moves, string _blackPlayer, string _whitePlayer)
        {
            Game newGame = new Game()
            {
                blackPlayer = _blackPlayer,
                whitePlayer = _whitePlayer
            };

            gameRepository.Add(newGame);

            foreach(var m in _moves)
            {
                moveRepository.Add(m);
            }
        }
    }
}
