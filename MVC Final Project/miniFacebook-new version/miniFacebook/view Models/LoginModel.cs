using System.ComponentModel.DataAnnotations;

namespace miniFacebook.view_Models
{
    public class LoginModel
    {
        [Required]
        [Key]
        public string Email { get; set;}
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set;}
    }
}
