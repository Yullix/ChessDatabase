using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Move
    {
        public int MoveID { get; set; }
        public int GameID { get; set; }
        public int startSqRow { get; set; }
        public int startSqColumn { get; set; }
        public int endSqRow { get; set; }
        public int endSqColumn { get; set; }
        public string color { get; set; }
        public string pieceAnnotation { get; set; }
        public int moveNumber { get; set; }
        
        public virtual Game Game { get; set; }

        //public Move(string startSq, string endSq, string color, string piece, int number)
        //{
        //    this.startSq = startSq;
        //    this.endSq = endSq;
        //    this.color = color;
        //    this.piece = piece;
        //    this.number = number;
        //}

        //public bool CheckLegality()
        //{
        //    var result = false;

        //    return result;
        //}
    }
}
