using Auth.Common;
using AuthJWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MockDatabase _mockDatabase;
        private readonly IOptions<AuthOptions> _authOptions;

        public AuthController(MockDatabase mockDatabase, IOptions<AuthOptions> authOptions)
        {
            _mockDatabase = mockDatabase;
            _authOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(new {access_token = token});
            }

            return Unauthorized();
        }

        public Account AuthenticateUser(string email, string password)
        {
            return _mockDatabase.Accounts.SingleOrDefault(x =>
                x.Email == email && x.Password == password);
        }

        private string GenerateToken(Account user)
        {
            var authparams = _authOptions.Value;
            var securityKey = authparams.GetSymetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(authparams.Issuer,
                authparams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authparams.TokenLifeTime),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}