using System.ComponentModel.DataAnnotations;

namespace user_dashboard.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Key]
        public int UserId {get; set;}

        [Required(ErrorMessage="First name cannot be blank")]
        [MinLength(4, ErrorMessage="First name must be more than 4 characters")]
        public string FirstName {get; set;}

        [Required(ErrorMessage="Last name cannot be blank")]
        [MinLength(4, ErrorMessage="Last name must be more than characters")]
        public string LastName {get; set;}

        [Required(ErrorMessage="Email cannot be blank")]
        public string Email {get; set;}

        [Required(ErrorMessage="Password cannot be blank")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [Compare("password", ErrorMessage="Passwords must match")]
        public string ConfirmPassword {get; set;}
    }
}