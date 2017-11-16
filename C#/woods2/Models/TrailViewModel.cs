using System.ComponentModel.DataAnnotations;

namespace woods2.Models{
    public class TrailViewModel : BaseEntity
    {
        [Key]
        public int TrailId { get; set; }

        [Required(ErrorMessage="You must enter a trail name")]
        public string TrailName { get; set; }

        [MinLength(10, ErrorMessage="Description must be at least 10 characters in length")]
        public string Description { get; set; }
        public int Length { get; set; }
        public int Elevation { get; set; }

        [Range(-180, 180, ErrorMessage="Longitude out of range")]
        public long Longitude { get; set; }
        
        [Range(-90, 90, ErrorMessage="Latitude out of range")]
        public long Latitude { get; set; }
        public string LongDegree { get; set; }
        public string LatDegree { get; set; }
    }
}