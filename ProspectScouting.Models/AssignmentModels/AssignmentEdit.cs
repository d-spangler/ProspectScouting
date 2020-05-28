using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.AssignmentModels
{
    public class AssignmentEdit
    {
        public int AssignmentID { get; set; }

        [Display(Name = "Assignment Details:")]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(3000, ErrorMessage = "There are too many characters in this field.")]
        public string AssignmentRequest { get; set; }

        [Display(Name = "School:")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        [Display(Name = "Scout:")]
        public int ScoutID { get; set; }

        public virtual Scout Scout { get; set; }

        
    }
}
