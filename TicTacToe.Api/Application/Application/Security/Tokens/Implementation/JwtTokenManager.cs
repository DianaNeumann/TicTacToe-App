using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Application.Configurations;
using Application.Security.Tokens.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Application.Security.Tokens.Implementation;

public class JwtTokenManager : ITokenManager
{
    public string CreateToken(Domain.Players.Player player)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, player.Name),
            new Claim(ClaimTypes.Sid, player.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            ApplicationConfiguration.JwtToken));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}