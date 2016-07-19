using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Player : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int rating { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        public ICollection<Match> matches { get; set; }

        public Player()
        {
            this.matches = new HashSet<Match>();
        }
    }
}
