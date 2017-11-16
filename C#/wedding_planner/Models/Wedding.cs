using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace wedding_planner.Models
{
    public class Wedding : BaseEntity {
        public long WeddingId {get; set;}
        public string Bride {get; set;}
        public string Groom {get; set;}
        public DateTime Date {get; set;}
        public List<Guest> Guests {get; set;}
        public DateTime Created_At {get;set;}
        public DateTime Updated_At {get;set;}

        public Wedding()
        {
            Guests = new List<Guest>();
        }
    }
}