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
    public class MoveService : IService
    {
        public event EventHandler Updated;
        private MoveRepository moveRepository;

        public MoveService(RepositoryFactory repoFactory)
        {
            moveRepository = repoFactory.GetMoveRepository();
        }

        /// <summary>
        /// Performs a move and depending on if the move is legal or not calls the repository to save it into the database
        /// </summary>
        /// <param name="position"></param>
        /// <param name="pieceAnnotation"></param>
        /// <param name="startSq"></param>
        /// <param name="endSq"></param>
        /// <param name="color"></param>
        /// <param name="gameID"></param>
        /// <param name="moveNumber"></param>
        /// <returns>bool value that represents if the move was successful or not</returns>
        public bool MakeMove(int[,] position, char pieceAnnotation, int[] startSq, int[] endSq, string color, int gameID, int moveNumber)
        {
            if (IsLegal(position, pieceAnnotation, startSq, endSq))
            {
                Move newMove = new Move()
                {
                    color = color,
                    endSqColumn = endSq[0],
                    endSqRow = endSq[1],
                    Id = gameID,
                    moveNumber = moveNumber,
                    pieceAnnotation = pieceAnnotation,
                    startSqColumn = startSq[0],
                    startSqRow = startSq[1]
                };

                moveRepository.Add(newMove);
            }
            else
                return false;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Help method for MakeMove that checks the legality
        /// </summary>
        /// <param name="position"></param>
        /// <param name="pieceAnnotation"></param>
        /// <param name="startSq"></param>
        /// <param name="endSq"></param>
        /// <returns>bool value representing if the move is legal or not</returns>
        private bool IsLegal(int[,] position, char pieceAnnotation, int[] startSq, int[] endSq)
        {
            throw new NotImplementedException();
        }
    }
}
