using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjetoJUST.Domain.Authentication;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Infra.Data.Authenticator;

public class TokenGenerator : ITokenGenerator
{
    public dynamic Generator(Usuario usuario)
    {
        var permission = string.Join(",",usuario.UsuarioPermissions.Select(x => x.Permission?.PermissionName));
        var claims = new List<Claim>
        {
            new Claim("Email", usuario.Email),
            new Claim("ID", usuario.Id.ToString()),
            new Claim ("Permissoes", permission)
        };

        var expires = DateTime.Now.AddDays(1);			
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6"));
        var tokenData = new JwtSecurityToken(			
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            expires: expires,
            claims: claims				
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
        return new
        {
            acess_token = token,
            expiration = expires
        };
    }
}