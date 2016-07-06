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
        
        public GameService(RepositoryFactory repoFactory)
        {
            gameRepository = repoFactory.GetGameRepository();
        }
    }
}
