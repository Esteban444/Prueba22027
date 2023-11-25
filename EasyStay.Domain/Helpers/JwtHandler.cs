using EasyStay.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyStay.Domain.Helpers
{
    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtConfiguration;
        private readonly UserManager<Users> _userManager;
        public JwtHandler(IConfiguration configuration, UserManager<Users> userManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.GetSection("JWTConfiguracion");
        }

        private SigningCredentials GetSignatureCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.GetSection("securityKey").Value!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email!)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtConfiguration.GetSection("validIssuer").Value,
                audience: _jwtConfiguration.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

        public async Task<string> CreateToken(Users user)
        {
            var firmacredenciales = GetSignatureCredentials();
            var claims = await GetClaims(user);
            var opcionestoken = GetTokenOptions(firmacredenciales, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(opcionestoken);

            return token;
        }

    }
}
