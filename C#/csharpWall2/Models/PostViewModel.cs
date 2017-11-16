using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace csharpWall2.Models
{
    public class PostViewModel : BaseEntity
    {
        public int PostId { get; set; }
        [Required]
        public string PostText { get; set; }
        public int UserId { get; set; }

    }
}