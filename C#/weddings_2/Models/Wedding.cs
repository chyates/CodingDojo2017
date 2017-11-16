using System;
using System.Collections.Generic;

namespace weddings_2.Models
{
    public class Wedding : BaseEntity
    {
        public int WeddingId {get; set; }
        public string WedderOne {get; set; }
        public string WedderTwo {get; set; }
        public DateTime Date {get; set; }
        public string Address {get; set; }
        public List<Guest> Guests {get; set;}

        public Wedding()
        {
            Guests = new List<Guest>();
        }
    }
}