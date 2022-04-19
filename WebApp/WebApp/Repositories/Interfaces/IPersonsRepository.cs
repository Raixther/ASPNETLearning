using WebApp.Models;

namespace WebApp.Repositories.Interfaces
{
	public interface IPersonsRepository:IEntitiesRepository<PersonEntity>
	{
		public PersonEntity GetByName(string name);
	
	}
}
