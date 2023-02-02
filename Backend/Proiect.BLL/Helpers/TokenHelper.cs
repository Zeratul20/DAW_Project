using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Proiect.BLL.Interfaces;
using Proiect.DAL.Entities;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Helpers
{
    public class TokenHelper : ITokenHelper
    {

        private readonly UserManager<User> _userManager;

        public TokenHelper(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateAccessToken(User _User)
        {
            var userId = _User.Id.ToString();
            var userName = _User.UserName;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName)
            };
            var roles = await _userManager.GetRolesAsync(_User);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var secret = "1234567891234567";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

