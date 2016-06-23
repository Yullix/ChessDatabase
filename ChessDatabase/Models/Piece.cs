using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Piece
    {
        public string name { get; set; }
        public string color { get; set; }
        public bool isCaptured { get; set; }
    }
}
