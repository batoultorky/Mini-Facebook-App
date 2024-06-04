using System.ComponentModel.DataAnnotations;

namespace miniFacebook.view_Models
{
    public class changePasswordModel
    {
        [Required]
        [Key]
        [DataType(DataType.Password)]
        public string oldPassword {  get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string newPassword {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        public string confirmNewPassword {  get; set; }
    }
}
