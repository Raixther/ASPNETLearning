namespace WebApp.Controllers.DataTransfer
{
	public class RegistrationRequest
	{
		public string Username{ get; set; }=string.Empty;	

		public string Password{ get; set; } = string.Empty;

		public string Role{ get; set; }=string.Empty;//переделать в адекватный тип, возможно enum
	}
}
