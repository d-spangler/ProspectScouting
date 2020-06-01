using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Data
{
    public enum Position { [Display(Name="Quarterback")] QB = 1,
        [Display(Name = "Running Back")] RB, [Display(Name = "Wide Receiver")] WR,
        [Display(Name = "Tight End")] TE, [Display(Name = "Offensive Tackle")] OT,
        [Display(Name = "Interior Offensive Line")] IOL, [Display(Name = "Interior Defensive Line")] IDL,
        [Display(Name = "Edge Rusher")] EDGE, [Display(Name = "Linebacker")] LB,
        [Display(Name = "Cornerback")] CB, [Display(Name = "Safety")] S,
        [Display(Name = "Punter/Kicker")] PK }

    public class Prospect
    {
        [Key]
        public int ProspectID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Position Position { get; set; }
        //public string Position { get; { return Enum.GetName(typeof(Position), Position )} }

        [Required]
        [ForeignKey("School")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }

        [Required]
        public string Report { get; set; }

        [Required]
        public decimal Grade { get; set; }

        [Required]
        public bool BigBoard { get; set; }
    }
}
