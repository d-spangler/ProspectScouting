﻿using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.AssignmentModels
{
    public class AssignmentCreate
    {
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(3000, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Request:")]
        public string AssignmentRequest { get; set; }

        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        public int ScoutID { get; set; }

        public virtual Scout Scout { get; set; }
    }
}
