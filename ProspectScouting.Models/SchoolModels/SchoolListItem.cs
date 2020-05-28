using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.SchoolModels
{
    public class SchoolListItem
    {
        public int SchoolID { get; set; }

        public string SchoolName { get; set; }

        public string City { get; set; }

        public State State { get; set; }
    }
}
