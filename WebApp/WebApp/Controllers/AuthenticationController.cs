using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.DataTransfer;
using WebApp.Entities;
using WebApp.Repositories.UsersRepository;
using WebApp.DataTransfer;
using WebApp.Cryptography;
using WebApp.JWT;
using WebApp.Validation;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IUsersRepository _usersRepository;

		private readonly ITokenGenerator _tokenGenerator;

		private readonly PasswordHashService _hashService;

		private readonly IValidator<RegistrationRequest> _validationService;

		//логгер для некорректно валидированных запросов

		public AuthenticationController(IUsersRepository usersRepository,
		ITokenGenerator tokenGenerator, PasswordHashService hashService, IValidator<RegistrationRequest> validationService) 
		{
			_usersRepository = usersRepository;
			_tokenGenerator = tokenGenerator;
			_hashService = hashService;
			_validationService = validationService;
		}

		[HttpPost("register")]

		public IActionResult Register(RegistrationRequest request)
		{
			_validationService.Validate(request);

			//код для возвращения результата валидации пользователю

			UserEntity user = new();

			_hashService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

			user.Username = request.Username;
			user.Role = request.Role;
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			_usersRepository.AddUser(user);

			return Ok(user);
		}

		[HttpPost("login")]

		public IActionResult Login(AuthenticationRequest request)//??добавить валидацию
		{

			var User = _usersRepository.GetUserByName(request.Username);

			if (User == null)
			{
				return BadRequest("User not found");
			}
			if (!_hashService.VerifyPasswordHash(request))
			{
				return BadRequest("WrongPassword");
			}

			return Ok(_tokenGenerator.GenerateToken(User));
		}


	}
}
