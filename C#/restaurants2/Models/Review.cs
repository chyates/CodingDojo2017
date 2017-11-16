using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace restaurants2.Models
{
    public class Review : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Reviewer { get; set; }

        [Required]
        public string Restaurant { get; set; }

        [Required]
        [MinLength(10, ErrorMessage="Your review must be longer than 10 characters")]
        public string ReviewContent { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }
        
        [Required]
        public int Rating { get; set; }
    }
}