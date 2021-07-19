using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TheWorkSchedulingApp.Models
{
    public class Day
    {
        public int DayId { get; set; }                     // PK

        // no error messages included bc users won't be entering - this is so 
        // EF will generate a non-null nvarchar with length shorter than max
        [StringLength(10)]
        [Required()]
        public string Name { get; set; }

        public ICollection<Position> Positions { get; set; }    // Navigation property
    }
}

