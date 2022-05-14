using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Entities;

namespace WebApp.JWT
{
	public class TokenGenerator:ITokenGenerator
	{

		private readonly IConfiguration _configuration;

		private readonly IRefreshTokenGenerator _refreshTokenGenerator;

		public TokenGenerator(IConfiguration configuration, IRefreshTokenGenerator refreshTokenGenerator)
		{
			_configuration = configuration;
			_refreshTokenGenerator = refreshTokenGenerator;
		}

		public AuthenticationResponse GenerateToken(UserEntity user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username),
				new Claim(ClaimTypes.Role, user.Role)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
			(_configuration.GetSection("Authentication:TokenKey").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddMinutes(20),
			signingCredentials: creds);


			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			var refreshToken = _refreshTokenGenerator.GenerateToken();

			return new AuthenticationResponse { JWTToken = jwt, RefreshToken = refreshToken };
		}
	}
}

