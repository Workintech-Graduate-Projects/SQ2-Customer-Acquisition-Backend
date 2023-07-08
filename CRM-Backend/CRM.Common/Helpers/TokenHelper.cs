using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common.Helpers
{
    public class TokenHelper
    {
        public static string CreateToken(string userName, int role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.Now.AddDays(1));

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public static string? GetUserRoleFromJwtToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var roleClaim = jwtSecurityToken.Claims.FirstOrDefault(r => r.Type == ClaimTypes.Role);
            return roleClaim?.Value;
        }
    }
}
