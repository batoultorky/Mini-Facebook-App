using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace miniFacebook.view_Models
{
    public class UserInfoModel
    {
        public string fullname { get; set; }
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be Male or Female.")]
        public string gender { get; set; }
        [AllowNull]
        public DateOnly? birthDate { get; set; }
        [AllowNull]
        public string? bio { get; set; }
    }
}
