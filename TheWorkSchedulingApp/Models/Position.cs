using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheWorkSchedulingApp.Models
{
    public class Position
    {
        public int PositionId { get; set; }                    // PK

        [StringLength(200, ErrorMessage = "PositionName may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a class title.")]
        public string PositionName { get; set; }

        [Range(100, 500, ErrorMessage = "Class number must be between 100 and 500.")]
        [Required(ErrorMessage = "Please enter a class number.")]
        public int? HoursPerShift { get; set; }

        [Display(Name = "MilitaryTime")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only for class time.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Class time must be 4 characters long.")]
        [Required(ErrorMessage = "Please enter a class time (in military time format).")]
        public string MilitaryTime { get; set; }

        public int WorkerId { get; set; }                  // Foreign key property
        public Worker Worker { get; set; }                // Navigation property

        public int DayId { get; set; }                      // Foreign key property
        public Day Day { get; set; }                        // Navigation property
    }
}
