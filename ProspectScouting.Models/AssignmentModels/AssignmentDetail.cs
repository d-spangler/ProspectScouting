using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.AssignmentModels
{
    public class AssignmentDetail
    {
        [Display(Name = "Assignment ID:")]
        public int AssignmentID { get; set; }

        [Display(Name = "Assignment Details:")]
        public string AssignmentRequest { get; set; }

        [Display(Name = "School:")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        [Display(Name = "Scout:")]
        public int ScoutID { get; set; }

        public virtual Scout Scout { get; set; }

        [Display(Name = "Completed?")]
        public bool Completed { get; set; }
    }
}
