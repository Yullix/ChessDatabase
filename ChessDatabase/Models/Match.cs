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

        public virtual ICollection<Move> Moves { get; set; }

        public Game()
        {
            this.Moves = new HashSet<Move>();
        }
    }
}
