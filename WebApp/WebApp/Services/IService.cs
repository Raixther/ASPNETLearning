namespace WebApp.Services
{
	public interface IService<T> where T:class
	{
		bool Create(T item);
		bool Update(T item);
		bool Delete(int id);
		T GetById<TUniqueId>(TUniqueId id) where TUniqueId: struct;
		IList<T> GetAll();
	}
}
