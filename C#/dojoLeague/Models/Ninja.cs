using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dojoLeague.Models 
{
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="You must enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage="You must enter a ninja level")]
        [Range(1, 10, ErrorMessage="Level must be between 1 and 10")]
        public int Level { get; set; }

        [Required(ErrorMessage="Dojo required. If not assigned to a Dojo, please select Rogue.")]
        public string DojoName { get; set; }
        public string Description { get; set; }
    }
}