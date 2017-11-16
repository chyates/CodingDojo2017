using System.ComponentModel.DataAnnotations;

namespace csharpLogin2.Models{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="That email is not valid")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Passwords must match")]
        public string PasswordConfirmation { get; set; }
    }
}