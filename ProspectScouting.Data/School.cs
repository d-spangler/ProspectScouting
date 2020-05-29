using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Data
{
    public enum State
    {
        [Description("Alabama")]
        AL,
        [Description("Alaska")]
        AK,
        [Description("Arkansas")]
        AR,
        [Description("Arizona")]
        AZ,
        [Description("California")]
        CA,
        [Description("Colorado")]
        CO,
        [Description("Connecticut")]
        CT,
        [Description("Delaware")]
        DE,
        [Description("Florida")]
        FL,
        [Description("Georgia")]
        GA,
        [Description("Hawaii")]
        HI,
        [Description("Iowa")]
        IA,
        [Description("Idaho")]
        ID,
        [Description("Illinois")]
        IL,
        [Description("Indiana")]
        IN,
        [Description("Kansas")]
        KS,
        [Description("Kentucky")]
        KY,
        [Description("Louisiana")]
        LA,
        [Description("Massachusetts")]
        MA,
        [Description("Maryland")]
        MD,
        [Description("Maine")]
        ME,
        [Description("Michigan")]
        MI,
        [Description("Minnesota")]
        MN,
        [Description("Missouri")]
        MO,
        [Description("Mississippi")]
        MS,
        [Description("Montana")]
        MT,
        [Description("North Carolina")]
        NC,
        [Description("North Dakota")]
        ND,
        [Description("Nebraska")]
        NE,
        [Description("New Hampshire")]
        NH,
        [Description("New Jersey")]
        NJ,
        [Description("New Mexico")]
        NM,
        [Description("Nevada")]
        NV,
        [Description("New York")]
        NY,
        [Description("Oklahoma")]
        OK,
        [Description("Ohio")]
        OH,
        [Description("Oregon")]
        OR,
        [Description("Pennsylvania")]
        PA,
        [Description("Rhode Island")]
        RI,
        [Description("South Carolina")]
        SC,
        [Description("South Dakota")]
        SD,
        [Description("Tennessee")]
        TN,
        [Description("Texas")]
        TX,
        [Description("Utah")]
        UT,
        [Description("Virginia")]
        VA,
        [Description("Vermont")]
        VT,
        [Description("Washington")]
        WA,
        [Description("Wisconsin")]
        WI,
        [Description("West Virginia")]
        WV,
        [Description("Wyoming")]
        WY,
        [Description("Washington, D.C.")]
        DC,
    }

    public class School
    {
        [Key]
        public int SchoolID { get; set; }

        [Required]
        [Display(Name = "School Name:")]
        public string SchoolName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public State State { get; set; }
    }
}
