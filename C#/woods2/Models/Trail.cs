using System;

namespace woods2.Models
{
    public class Trail : BaseEntity
    {
        public int TrailId { get; set; }
        public string TrailName { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Elevation { get; set; }
        public long Longitude { get; set; }
        public string LongDegree { get; set; }
        public long Latitude { get; set; }
        public string LatDegree { get; set; }
    }
}