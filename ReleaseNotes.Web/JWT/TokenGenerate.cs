using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ReleaseNotes.Web.Context;
using ReleaseNotes.Web.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReleaseNotes.Web.JWT
{
    public class TokenGenerate : ITokenGenerate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public TokenGenerate(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public UserToken LoginTokenGenerate(LoginViewModel login)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = _configuration["TokenConfiguration:ExpireHours"];
            var expirationTime = DateTime.UtcNow.AddHours(double.Parse(expiration));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials);



            return new UserToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirationTime,
                Message = "Token JWT OK",
            };

        }

        public UserToken RegisterTokenGenerate(RegisterViewModel register)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, register.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = _configuration["TokenConfiguration:ExpireHours"];
            var expirationTime = DateTime.UtcNow.AddHours(double.Parse(expiration));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials);



            return new UserToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirationTime,
                Message = "Token JWT OK",
            };
        }

    }
}
