using System.ComponentModel.DataAnnotations;
using Friends.Localization;

namespace Friends.Api.Users.Models
{
    public class LoginRequest
    {
        #region Constructors
        public LoginRequest()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
        #endregion

        #region Properties
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessages.Email), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        #endregion
    }
}
