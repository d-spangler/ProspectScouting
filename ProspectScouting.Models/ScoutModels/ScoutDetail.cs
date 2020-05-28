using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.ScoutModels
{
    public class ScoutDetail
    {
        [Display(Name = "Scout ID:")]
        public int ScoutID { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
    }
}
