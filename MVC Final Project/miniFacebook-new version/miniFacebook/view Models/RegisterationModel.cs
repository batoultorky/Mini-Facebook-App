using miniFacebook.Helprs;
using System.ComponentModel.DataAnnotations;


namespace miniFacebook.view_Models
{
    public class RegisterationModel
    {
        [Required]
        [Key]
        [StringLength(50,MinimumLength =3 )]
        public string fullname {  get; set; }

        [Required]
        [StringLength(50 )]
        public string UserName {  get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [UniqueEmal]
        public string Email { get; set; }
        [Required(ErrorMessage ="must specific gender")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be Male or Female.")]
        public string gender {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
    }
}
