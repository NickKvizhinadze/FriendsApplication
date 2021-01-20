using System;

namespace Friends.Api.Users.Models
{
    public class LoginDto
    {
        #region Constructor
        public LoginDto()
        {
            Id = Guid.NewGuid().ToString();
            Email = string.Empty;
            Token = string.Empty;
        }
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        #endregion
    }
}
