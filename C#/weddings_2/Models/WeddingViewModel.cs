using System;
using System.ComponentModel.DataAnnotations;

namespace weddings_2.Models
{
    public class WeddingViewModel : BaseEntity
    {
        [Key]
        public int WeddingId {get; set; }

        [Required(ErrorMessage="You must enter a first wedder")]
        public string WedderOne {get; set;}

        [Required(ErrorMessage="You must enter a second wedder")]
        public string WedderTwo {get; set; }
        
        [Required(ErrorMessage="You must enter an address")]
        public string Address {get; set; }

        [Required(ErrorMessage="You must enter a date")]
        public DateTime Date {get; set; }
    }
}