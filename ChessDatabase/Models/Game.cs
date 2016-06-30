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
            position[0, 1] = "wN";
            position[0, 2] = "wB";
            position[0, 3] = "wQ";
            position[0, 4] = "wK";
            position[0, 5] = "wB";
            position[0, 6] = "wN";
            position[0, 7] = "wR";
            position[1, 0] = "wP";
            position[1, 1] = "wP";
            position[1, 2] = "wP";
            position[1, 3] = "wP";
            position[1, 4] = "wP";
            position[1, 5] = "wP";
            position[1, 6] = "wP";
            position[1, 7] = "wP";

            //Black starting position
            position[7, 0] = "bR";
            position[7, 1] = "bN";
            position[7, 2] = "bB";
            position[7, 3] = "bQ";
            position[7, 4] = "bK";
            position[7, 5] = "bB";
            position[7, 6] = "bN";
            position[7, 7] = "bR";
            position[6, 0] = "bP";
            position[6, 1] = "bP";
            position[6, 2] = "bP";
            position[6, 3] = "bP";
            position[6, 4] = "bP";
            position[6, 5] = "bP";
            position[6, 6] = "bP";
            position[6, 7] = "bP";

            this.Moves = new HashSet<Move>();
        }
    }
}
