using Karkathamizha.API.Model.AppSettings;
using Karkathamizha.API.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Karkathamizha.API.IRepository;

namespace Karkathamizha.API.Service.ServiceConfiguration
{
    public class TokenGeneration: ITokenGeneration
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRolesRepository _userRoleRepository;

        public TokenGeneration(IOptions<JwtSettings> jwtSettings, IUserRolesRepository userRoleRepository)
        {
            _jwtSettings = jwtSettings.Value;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.secretKey));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>()
            {
                new Claim(nameof(user.UserId), user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.GivenName,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var roles = await _userRoleRepository.GetUserRole(user.UserId);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new List<Claim>
                //{
                //    new Claim(nameof(user.UserId), user.UserId.ToString()),
                //    new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                //    new Claim(JwtRegisteredClaimNames.GivenName,user.UserName),
                //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                //    //new Claim(ClaimTypes.Role,user.Roles?.ToString()),
                //}),
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpireMinutes),
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
