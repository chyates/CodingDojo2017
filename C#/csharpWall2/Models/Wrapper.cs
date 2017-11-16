using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace csharpWall2.Models
{
    public class Wrapper : BaseEntity {
        public List<User> Users {get; set;}
        public List<Post> Posts {get; set;}
        public List<Comment> Comments {get; set;}

        public Wrapper(List<User> users, List<Post> posts, List<Comment> comments)
        {
            Users = users;
            Posts = posts;
            Comments = comments;
        }
    }
}