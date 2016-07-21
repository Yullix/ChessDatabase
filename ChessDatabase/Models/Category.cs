using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDatabase.Models
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }

        public virtual ICollection<Match> matches { get; set; }

        public Category()
        {
            this.matches = new HashSet<Match>();
        }

        public override string ToString()
        {
            return name;
        }
    }
}
