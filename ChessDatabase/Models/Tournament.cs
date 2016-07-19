using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Tournament : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public ICollection<Match> matches { get; set; }

        public Tournament()
        {
            this.matches = new HashSet<Match>();
        }
    }
}
