namespace WebApp
{
	public class AuthenticationResponse
	{
		public string JWTToken { get; set; } = string.Empty;

		public string RefreshToken { get; set; } = string.Empty;
	}
}
