using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.AssignmentModels
{
    public class AssignmentListItem
    {
        public int AssignmentID { get; set; }

        public string AssignmentRequest { get; set; }

        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        public int ScoutID { get; set; }

        public virtual Scout Scout { get; set; }
    }
}
