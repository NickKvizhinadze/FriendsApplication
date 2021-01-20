using System;
using System.Text;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using DotNetHelpers.Models;
using DotNetHelpers.Logger;
using DotNetHelpers.MvcCore;
using DotNetHelpers.MvcCore.Attributes;
using Friends.Localization;
using Friends.Common.Models;
using Friends.Api.Users.Models;

namespace Friends.Api.Users
{
    [Authorize]
    public class AccountController : ApiBaseController
    {
        #region Fields
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogService _logger;
        private readonly AppSettings _settings;
        #endregion

        #region Constructors
        public AccountController(
           UserManager<IdentityUser> userManager,
           SignInManager<IdentityUser> signInManager,
           ILogService logService,
           IOptionsSnapshot<AppSettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logService;
            _settings = options.Value;
        }
        #endregion

        #region Actions
        [HttpPost("Authorize")]
        [AllowAnonymous]
        [ModelState]
        public async Task<ActionResult<LoginDto>> Authorize([FromBody] LoginRequest model)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var result = new LoginDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = GenerateJwtTokenAsync(user, (await _userManager.GetRolesAsync(user)).ToList(), model.RememberMe)
                };
                return Ok(result);
            }

            AddError(ErrorMessages.InvalidLoginAttempt);
            return BadRequest(ModelState);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        [ModelState]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var user = new IdentityUser(model.Email);
            var registerResult = await _userManager.CreateAsync(user, model.Password);
            if (registerResult.Succeeded)
                return Ok();

            AddErrors(registerResult);
            return BadRequest(ModelState);
        }

        #endregion

        #region Private Methods
        private string GenerateJwtTokenAsync(IdentityUser user, List<string>? roles, bool isPersistent)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (roles != null && roles.Count > 0)
                foreach (var item in roles)
                    claims.Add(new Claim(ClaimTypes.Role, item));

            var jwtSettings = _settings.Jwt;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Jwt.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = isPersistent ? DateTime.Now.AddDays(jwtSettings.ExpireDaysWithRemember) : DateTime.Now.AddHours(jwtSettings.ExpireDays);

            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void AddError(string errorMessage)
        {
            ModelState.AddModelError("Error", errorMessage);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        #endregion
    }
}
