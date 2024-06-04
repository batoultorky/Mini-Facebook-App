using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace miniFacebook.Models
{
    public class Applicationuser:IdentityUser
    {
       
        public string fullname { get; set; }
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be Male or Female.")]
        public string gender { get; set; }
        [AllowNull]
        public DateOnly? birthDate { get; set; }
        [AllowNull]
        public string? bio { get; set; }

      
        public string photo { get; set; }
        
       
        [AllowNull]
        public virtual List<Post>? posts { get; set; }
    }
}
