using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace weddings_2.Models
{
    public class Wrapper : BaseEntity {
        public List<Wedding> Weddings {get; set;}
        public List<Guest> Guests {get; set;}

        public Wrapper(List<Wedding> weddings, List<Guest> guests)
        {
            Weddings = weddings;
            Guests = guests;
        }
    }
}