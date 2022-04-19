using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
	public class BaseEntity<TUniqueId> where TUniqueId: struct
	{
		[Column("Id")]
		public TUniqueId Id { get; set; }

		[Column("IsDeleted")]
		public bool isDeleted { get; set; }
	}
}
