using System.Security.Cryptography;
using System.Text;
using WebApp.DataTransfer;
using WebApp.Repositories.UsersRepository;

namespace WebApp.Cryptography
{
	public class PasswordHashService
	{
		private readonly IUsersRepository _usersRepository;

		public PasswordHashService(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;
		}
		public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			var hmac = new HMACSHA512();

			passwordSalt = hmac.Key;
			passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}

		public bool VerifyPasswordHash(AuthenticationRequest request)
		{
			var user = _usersRepository.GetUserByName(request.Username);
			var hmac = new HMACSHA512(user.PasswordSalt);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
			return computedHash.SequenceEqual(user.PasswordHash);
		}
	}
}


