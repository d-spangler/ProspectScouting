using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.Prospect
{
    public class ProspectListItem
    {
        public int ProspectID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Position Position { get; set; }

        public int SchoolID { get; set; }
        
        public virtual School School { get; set; }

        [Display(Name = "Notes")]
        public string ScoutingReport { get; set; }

        public decimal Grade { get; set; }

        [Display(Name = "On Big Board")]
        public bool BigBoard { get; set; }
    }
}
