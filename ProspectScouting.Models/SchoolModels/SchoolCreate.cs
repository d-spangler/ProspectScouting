using ProspectScouting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProspectScouting.Models.SchoolModels
{
    public class SchoolCreate
    {
        [Required]
        [Display(Name = "Name of Institution:")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "City:")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State:")]
        public State State { get; set; }

        public IEnumerable<SelectListItem> Schools { get; set; }
    }
}
