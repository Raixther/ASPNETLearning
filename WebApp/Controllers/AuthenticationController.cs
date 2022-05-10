using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using WebApp.Controllers.DataTransfer;
using WebApp.Entities;
using WebApp.Repositories.UsersRepository;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUsersRepository _usersRepository;

		private readonly IConfiguration _configuration;
		public AuthenticationController(IUsersRepository usersRepository, IConfiguration configuration)
		{
			_usersRepository = usersRepository;
			_configuration = configuration;
		}

		[HttpPost("register")]

		public IActionResult Register(UserDTO request)
		{
			UserEntity user = new();

			CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

			user.Username= request.Username;
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			return Ok(user);
			
		}

		[HttpPost("login")]

		public IActionResult Login(UserDTO request)
		{
			if(_usersRepository.GetUserByName(request.Username)==null)
			{
				return BadRequest("User not found");
			}
			if(!VerifyPasswordHash(request))
			{
				return BadRequest("WrongPassword");
			}
			return Ok("token");
		}
		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{ 
			using(var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private bool VerifyPasswordHash(UserDTO request)
		{
			UserEntity user = _usersRepository.GetUserByName(request.Username);

			using(var hmac = new HMACSHA512(user.PasswordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
				return computedHash.SequenceEqual(user.PasswordHash);
			}

		}

		private string CreateToken(UserEntity user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Username)
			};

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
			(_configuration.GetSection("Authentication:TokenKey").Value));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddMinutes(20),
			signingCredentials: creds); 
			

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}
	}
}
