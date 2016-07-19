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
        [MaxLength(30)]
        public string blackPlayer { get; set; }

        [Required]
        [MaxLength(30)]
        public string whitePlayer { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }

        public virtual Category category { get; set; }
    }
}
