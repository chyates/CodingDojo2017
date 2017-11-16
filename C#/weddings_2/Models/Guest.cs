using System;
using System.Collections.Generic;

namespace weddings_2.Models
{
    public class Guest : BaseEntity
    {
        public int GuestId {get; set; }
        public int UserId {get; set;}
        public int WeddingId {get; set; }
        public Wedding Wedding {get; set; }
    }
}