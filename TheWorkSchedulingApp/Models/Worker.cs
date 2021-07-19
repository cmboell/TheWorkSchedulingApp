using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheWorkSchedulingApp.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }                    // PK

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "First name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        public ICollection<Position> Positions { get; set; }       // Navigation property

        // readonly display property
        public string FullName => $"{FirstName} {LastName}";
    }
}
