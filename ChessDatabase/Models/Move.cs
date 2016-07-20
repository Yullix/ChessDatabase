using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Move
    {
        public int gameId { get; set; }

        public int moveNumber { get; set; }

        public int whitePlyId { get; set; }

        public int blackPlyId { get; set; }

        public Game game { get; set; }

        public Ply whitePly { get; set; }

        public Ply blackPly { get; set; }

        public override string ToString()
        {            
            if(blackPly == null)
            {
                return moveNumber + ". " + whitePly.plyAnnotation;
            }

            return moveNumber + ". " + whitePly.plyAnnotation + "  " + blackPly.plyAnnotation;
        }
    }
}
