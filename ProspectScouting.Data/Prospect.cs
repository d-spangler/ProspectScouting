using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Data
{
    public enum Position { QB = 1, RB, WR, TE, OT, IOL, IDL, EDGE, LB, CB, S, PK }

    public class Prospect
    {
        [Key]
        public int ProspectID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public School School { get; set; }

        [Required]
        public string ScoutingReport { get; set; }

        [Required]
        public decimal Grade { get; set; }

        [Required]
        public bool BigBoard { get; set; }
    }
}
