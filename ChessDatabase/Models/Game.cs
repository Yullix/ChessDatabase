using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ted Torkkeli
// 2016-07-05

namespace ChessDatabase.Models
{
    public class Game : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string blackPlayer { get; set; }

        [Required]
        [MaxLength(30)]
        public string whitePlayer { get; set; }

        public DateTime date { get; set; }

        public string name { get; set; }

        public virtual ICollection<Move> Moves { get; set; }

        public Game()
        {
            this.Moves = new HashSet<Move>();
        }
    }
}
