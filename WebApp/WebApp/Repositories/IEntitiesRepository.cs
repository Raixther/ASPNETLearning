using WebApp.Models;

namespace WebApp.Repositories
{
	public interface IEntitiesRepository<T> where T:class 
	{
		public bool Add(T entity);

		public IEnumerable<T> GetAll();

		public PersonEntity GetById<TUniqueId>(TUniqueId id) where TUniqueId:struct;

		public bool Delete(int id);

		public bool Update(T entity);
	}
}
