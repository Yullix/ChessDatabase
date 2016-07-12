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
    public class Move : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int GameId { get; set; }

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
        public int moveNumber { get; set; }
        
        public virtual Game Game { get; set; }
    }
}
