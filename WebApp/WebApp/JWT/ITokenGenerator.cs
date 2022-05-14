using WebApp.Entities;

namespace WebApp.JWT
{
	public interface ITokenGenerator
	{
		public AuthenticationResponse GenerateToken(UserEntity user);
	}
}
