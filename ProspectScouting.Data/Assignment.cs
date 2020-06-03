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
        public Guid OwnerID { get; set; }

        [Required]
        public string AssignmentRequest { get; set; }

        public int SchoolID { get; set; }

        [ForeignKey(nameof(SchoolID))]
        public virtual School School { get; set; }

        public int ScoutID { get; set; }

        [ForeignKey(nameof(ScoutID))]
        public virtual Scout Scout { get; set; }

        public bool Completed { get; set; }
    }
}
