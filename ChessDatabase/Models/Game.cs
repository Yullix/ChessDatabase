using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Game
    {
        public string blackPlayer { get; set; }
        public string whitePlayer { get; set; }
        public string [,] position { get; set; }
        public int GameID { get; set; }

        public virtual ICollection<Move> Moves { get; set; }

        public Game()
        {
            position = new string[8, 8];

            // White starting position
            position[0, 0] = "wR";
            position[1, 0] = "wN";
            position[2, 0] = "wB";
            position[3, 0] = "wQ";
            position[4, 0] = "wK";
            position[5, 0] = "wB";
            position[6, 0] = "wN";
            position[7, 0] = "wR";
            position[0, 1] = "wP";
            position[1, 1] = "wP";
            position[2, 1] = "wP";
            position[3, 1] = "wP";
            position[4, 1] = "wP";
            position[5, 1] = "wP";
            position[6, 1] = "wP";
            position[7, 1] = "wP";

            //Black starting position
            position[0, 7] = "bR";
            position[1, 7] = "bN";
            position[2, 7] = "bB";
            position[3, 7] = "bQ";
            position[4, 7] = "bK";
            position[5, 7] = "bB";
            position[6, 7] = "bN";
            position[7, 7] = "bR";
            position[0, 6] = "bP";
            position[1, 6] = "bP";
            position[2, 6] = "bP";
            position[3, 6] = "bP";
            position[4, 6] = "bP";
            position[5, 6] = "bP";
            position[6, 6] = "bP";
            position[7, 6] = "bP";

            this.Moves = new HashSet<Move>();
        }
    }
}
