using miniFacebook.Models;
using miniFacebook.view_Models;
using System.ComponentModel.DataAnnotations;

namespace miniFacebook.Helprs
{
    public class UniqueEmalAttribute:ValidationAttribute
    {
       // public ecommerceDbcontext db;
        public UniqueEmalAttribute()
        {

        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? email = value?.ToString();

            if (email != null && validationContext.ObjectInstance is RegisterationModel user)
            {
                var db = (facebookDbcontext)validationContext.GetService(typeof(facebookDbcontext));
                if (!db.users.Any(s => s.Email == email))
                    return ValidationResult.Success;
            }
            return new ValidationResult("Email is already Exist");


        }
    }
}
