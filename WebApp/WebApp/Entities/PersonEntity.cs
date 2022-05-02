using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
[Table("Persons")]
	public class PersonEntity
	{
		[Column("id")]
		[Key]
		public int Id { get; set; } 

		[Column("name")]
		public string Name{ get; set; } = string.Empty;

	}
}
