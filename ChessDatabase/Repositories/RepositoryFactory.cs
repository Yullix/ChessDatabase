using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

//Ted Torkkeli
// 2016-07-05
namespace ChessDatabase.Repositories
{
    /// <summary>
    /// Handles all repository instances
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// Gets the context singleton for the database context
        /// </summary>
        static ChessDatabaseContext context
        {
            get
            {
                return ContextSingleton.GetContext();
            }
        }

        /// <summary>
        /// Gets an instance of GameRepository
        /// </summary>
        /// <returns>new instance of GameRepository</returns>
        //public GameRepository GetGameRepository()
        //{
        //    return new GameRepository(context);
        //}

        /// <summary>
        /// Gets an instance of MoveRepository
        /// </summary>
        /// <returns>new instance of MoveRepository</returns>
        public MoveRepository GetMoveRepository()
        {
            return new MoveRepository(context);
        }

        public MatchRepository GetMatchRepository()
        {
            return new MatchRepository(context);
        }

        public PlayerRepository GetPlayerRepository()
        {
            return new PlayerRepository(context);
        }

        public CategoryRepository GetCategoryRepository()
        {
            return new CategoryRepository(context);
        }

        public OpeningRepository GetOpeningRepositry()
        {
            return new OpeningRepository(context);
        }

        public TournamentRepository GetTournamentRepository()
        {
            return new TournamentRepository(context);
        }
    }
}
