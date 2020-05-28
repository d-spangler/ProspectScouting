using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProspectScouting.Models.ScoutModels
{
    public class ScoutCreate
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
    }
}
