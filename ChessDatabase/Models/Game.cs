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

        public string name { get; set; }

        public virtual ICollection<Ply> plies { get; set; }

        public Game()
        {
            this.plies = new HashSet<Ply>();
        }
    }
}
