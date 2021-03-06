using System.ComponentModel.DataAnnotations;
namespace weddings_2.Models
{
    public class RegisterViewModel : BaseEntity {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage="You must enter an email")]
        [MinLength(3, ErrorMessage="Email must be at least 3 characters")]
        [MaxLength(20, ErrorMessage="Email cannot be more than 20 characters")]
        public string Email {get; set;}

        [Required(ErrorMessage="You must enter a password")]
        [MinLength(8, ErrorMessage="Password cannot be less than 8 characters")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [Required(ErrorMessage="Plase confirm password")]
        [Compare("Password", ErrorMessage="Passwords do not match")]
        public string ConfirmPassword {get; set;}

        [Required(ErrorMessage="You must enter a first name")]
        public string FirstName {get; set;}
        
        [Required(ErrorMessage="You must enter a last name")]
        public string LastName {get; set;}
    }
}