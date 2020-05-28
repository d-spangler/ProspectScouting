using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Data
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        public string AssignmentRequest { get; set; }

        [Required]
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public School School { get; set; }

        [Required]
        [ForeignKey("Scout")]
        public int ScoutID { get; set; }
        public Scout Scout { get; set; }
    }
}
