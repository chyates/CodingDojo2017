using System.Collections.Generic;

namespace woods2.Models
{
    public class Wrapper : BaseEntity {
        public List<Trail> Trails { get; set; }
        public Wrapper(List<Trail> trails)
        {
            Trails = trails;
        }
    }
}