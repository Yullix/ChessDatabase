using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Models
{
    public class Ply : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("game")]
        public int gameId { get; set; }

        [Required]
        public int startSqRow { get; set; }

        [Required]
        public int startSqColumn { get; set; }

        [Required]
        public int endSqRow { get; set; }

        [Required]
        public int endSqColumn { get; set; }

        [Required]
        public string color { get; set; }

        [Required]
        public char pieceAnnotation { get; set; }

        [Required]
        public string plyAnnotation { get; set; }

        [Required]
        public int moveNumber { get; set; }

        public string capturedPieceAnnotation { get; set; }

        public virtual Game game { get; set; }

        public override string ToString()
        {
            char column = 'a';

            switch(endSqColumn)
            {
                case 1:
                    column = 'b';
                    break;
                case 2:
                    column = 'c';
                    break;
                case 3:
                    column = 'd';
                    break;
                case 4:
                    column = 'e';
                    break;
                case 5:
                    column = 'f';
                    break;
                case 6:
                    column = 'g';
                    break;
                case 7:
                    column = 'h';
                    break;
            }

            string returnvalue = "";

            if(pieceAnnotation == 'P')
            {
                if (capturedPieceAnnotation == "")
                    returnvalue = " " + column + (endSqRow + 1);
                else
                {
                    char startColumn = 'a';

                    switch (startSqColumn)
                    {
                        case 1:
                            startColumn = 'b';
                            break;
                        case 2:
                            startColumn = 'c';
                            break;
                        case 3:
                            startColumn = 'd';
                            break;
                        case 4:
                            startColumn = 'e';
                            break;
                        case 5:
                            startColumn = 'f';
                            break;
                        case 6:
                            startColumn = 'g';
                            break;
                        case 7:
                            startColumn = 'h';
                            break;
                    }
                    returnvalue = startColumn + "x" + column + (endSqRow + 1);
                }
            }
            else
            {
                if (capturedPieceAnnotation == "")
                    returnvalue = pieceAnnotation.ToString() + column + (endSqRow + 1);
                else
                    returnvalue = pieceAnnotation.ToString() + "x" + column + (endSqRow + 1);
            }
            return returnvalue;
        }
    }
}
