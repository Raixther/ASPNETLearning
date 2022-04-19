using WebApp.Models;

namespace WebApp.Services
{
	public interface IPersonsService:IService<PersonEntity>
	{
		public PersonEntity GetByName(string name);
	}
}
