using System;
using System.Collections.Generic;

namespace csharpBoiler.Models
{
    public class Wrapper : BaseEntity
    {
        // ADD LISTS OF EVERY MODEL TYPE AS NECESSARY
        public List<User> Users { get; set;}

        public Wrapper(List<User> users)
        {
            Users = users;
        }
    }
}