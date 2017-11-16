using System.ComponentModel.DataAnnotations;

namespace restaurants
{
    public class Review
    {
        public string Reviewer {get; set;}
        public string Restaurant {get; set;}
        public string Content {get; set;}
        // public something Date {get; set; }
    }
}