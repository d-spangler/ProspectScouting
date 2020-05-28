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
    public class ProspectListItem
    {
        public int ProspectID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Position Position { get; set; }

        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        public string Report { get; set; }

        public decimal Grade { get; set; }

        public bool BigBoard { get; set; }
    }
}
