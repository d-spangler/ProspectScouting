﻿using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProspectScouting.Models.ProspectModels
{
    public class ProspectCreate
    {
        [Required]
        [Display(Name = "First Name:")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name:")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Position:")]
        public Position Position { get; set; }

        [Display(Name = "School:")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        [Required]
        [Display(Name = "Scouting Notes:")]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(3000, ErrorMessage = "There are too many characters in this field.")]
        public string Report { get; set; }

        [Required]
        [Display(Name = "Grade (X.XX/10.00):")]
        public decimal Grade { get; set; }

        [Required]
        [Display(Name = "Add to the Big Board?")]
        public bool BigBoard { get; set; }
    }
}
