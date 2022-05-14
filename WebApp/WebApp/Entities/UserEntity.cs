using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
		[Table("Users")]
	public class UserEntity
	{	
		[Column("Username")]
		[Key]
		public string Username{ get;set;}=string.Empty;

		[Column("Role")]
		public string Role { get; set; } = string.Empty;

		[Column("PasswordHash")]
		public byte[] PasswordHash{ get; set; }
		[Column("PasswordSalt")]
		public byte[] PasswordSalt{ get; set; }
	}
}
