using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Web.Features.Common.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MinimalApi.Web.Features.Common
{
    public class LoginEndpointBehaviour
    {
        [AllowAnonymous]
        public static IResult Login([FromBody] UserCredentials credentials, IConfiguration config)
        {
            //Authenticate
            var user = Authenticate(credentials);
            if (user == null)
                return Results.NotFound("User not found!");

            //Generate Token
            var token = GenerateToken(user, config);
            return Results.Ok(token);
        }

        private static User Authenticate(UserCredentials credentials)
        {
            if (credentials == null
                || (!credentials?.UserName?.Equals(Constants.UserName) ?? false)
                || (!credentials?.Password?.Equals(Constants.Password) ?? false))
                return null;

            return new User
            {
                UserName = credentials.UserName,
                Password = credentials.Password,
                Email = Constants.Email,
                Role = Constants.Role
            };
        }

        private static string GenerateToken(User user, IConfiguration config)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken (config["Jwt:Issuer"], config["Jwt:Audience"], claims
                , expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
