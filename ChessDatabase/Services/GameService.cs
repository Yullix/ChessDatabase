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
            try
            {
                int gameID = Guid.NewGuid().GetHashCode();

                Game newGame = new Game()
                {
                    blackPlayer = _blackPlayer,
                    whitePlayer = _whitePlayer,
                    GameID = gameID
                };

                gameRepository.Add(newGame);

                foreach (var m in _moves)
                {
                    m.GameID = gameID;
                    moveRepository.Add(m);
                }
            }
            catch(NotUniqueIdException)
            {
                Add(_moves, _blackPlayer, _whitePlayer);
            }
        }
    }
}
