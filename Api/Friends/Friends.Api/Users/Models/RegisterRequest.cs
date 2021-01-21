using System.ComponentModel.DataAnnotations;
using Friends.Localization;

namespace Friends.Api.Users.Models
{
    public class RegisterRequest
    {
        #region Constructors
        public RegisterRequest()
        {
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
        #endregion

        #region Properties
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessages.Email), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = nameof(ErrorMessages.MinAndMaxLength), ErrorMessageResourceType = typeof(ErrorMessages), MinimumLength = 5)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessageResourceName = nameof(ErrorMessages.PasswordCompare), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string ConfirmPassword { get; set; }
        #endregion
    }
}
