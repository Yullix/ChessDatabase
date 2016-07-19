using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Match : Game
    {
        [Required]
        [ForeignKey("blackPlayer")]
        public int blackPlayerId { get; set; }

        [Required]
        [ForeignKey("whitePlayer")]
        public int whitePlayerId { get; set; }

        [ForeignKey("category")]
        public Nullable<int> categoryId { get; set; }

        public virtual Category category { get; set; }

        public virtual Player blackPlayer { get; set; }

        public virtual Player whitePlayer { get; set; }
    }
}
