using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.ProspectModels
{
    public class ProspectDetail
    {
        [Display(Name = "Prospect ID:")]
        public int ProspectID { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Position:")]
        public Position Position { get; set; }

        [Display(Name = "School:")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        [Display(Name = "Scouting Notes:")]
        public string Report { get; set; }

        [Display(Name = "Grade:")]
        public decimal Grade { get; set; }

        [Display(Name = "Big Board:")]
        public bool BigBoard { get; set; }

    }
}
