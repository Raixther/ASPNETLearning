using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
	[Table("Persons", Schema ="vma")]
	public class PersonEntity:BaseEntity<int>
	{
		[Column("Name")]
		public string Name{ get; set; }
	}
}
