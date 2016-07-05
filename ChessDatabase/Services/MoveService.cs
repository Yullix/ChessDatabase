using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDatabase.Models;

namespace ChessDatabase.Services
{
    public class MoveService : IService
    {
        public event EventHandler Updated;

        public bool MakeMove(int[,] position, string pieceAnnotation, int[] startSq, int[] endSq, string color, int gameID, int moveNumber)
        {
            if (IsLegal(position, pieceAnnotation, startSq, endSq))
            {
                new Move()
                {
                    color = color,
                    endSqColumn = endSq[0],
                    endSqRow = endSq[1],
                    GameID = gameID,
                    moveNumber = moveNumber,
                    pieceAnnotation = pieceAnnotation,
                    startSqColumn = startSq[0],
                    startSqRow = startSq[1]
                };
            }
            else
                return false;
            throw new NotImplementedException();
        }

        private bool IsLegal(int[,] position, string pieceAnnotation, int[] startSq, int[] endSq)
        {
            throw new NotImplementedException();
        }
    }
}
