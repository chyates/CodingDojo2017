using System.ComponentModel.DataAnnotations;

namespace csharpWall2.Models
{
    public class CommentViewModel : BaseEntity
    {
        [Key]
        public int CommentId {get; set;}
        [Required]
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

    }
}