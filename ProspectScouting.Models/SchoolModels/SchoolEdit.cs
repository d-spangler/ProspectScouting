using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.SchoolModels
{
    public class SchoolEdit
    {
        public int SchoolID { get; set; }

        [Display(Name = "School Name:")]
        public string SchoolName { get; set; }

        [Display(Name = "City:")]
        public string City { get; set; }

        [Display(Name = "State:")]
        public State State { get; set; }
    }
}
