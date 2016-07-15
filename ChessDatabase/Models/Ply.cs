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
        [ForeignKey("Move")]
        public int moveId { get; set; }

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

        public virtual Move move { get; set; }

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

            return moveNumber.ToString() + ". " + pieceAnnotation + column + (endSqRow + 1);
        }
    }
}
