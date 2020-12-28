namespace GoodWeebs.Web.CustomValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using GoodWeebs.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class DisplayName : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (UserManager<ApplicationUser>)validationContext.GetService(typeof(UserManager<ApplicationUser>));

            var user = context.Users.Where(x => x.DisplayName == (string)value).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                return new ValidationResult("Display name is taken!");
            }
        }
    }
}
