using System.Security.Cryptography;

namespace WebApp.JWT
{
	public class RefreshTokenGenerator : IRefreshTokenGenerator
	{ 
		public string GenerateToken()//?? время жизни рефреша
		{
			var randomNumber =	new byte[32];
			var randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
			
		}
	}
}
