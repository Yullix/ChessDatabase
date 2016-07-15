using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Move : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int gameId { get; set; }

        [Required]
        public int moveNumber { get; set; }

        [ForeignKey("Ply")]
        public int whitePlyId { get; set; }

        [ForeignKey("Ply")]
        public int blackPlyId { get; set; }

        public virtual Game game { get; set; }

        public virtual Ply whitePly { get; set; }

        public virtual Ply blackPly { get; set; }

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
