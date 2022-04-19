using Microsoft.EntityFrameworkCore;

using WebApp.Database;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Repositories
{
	public class PersonsRepository : IPersonsRepository
	{

		private readonly PersonsDbContext _context;

		public PersonsRepository(PersonsDbContext context)
		{
			_context =context;
		}

		public bool Add(PersonEntity personEntity)
		{
			try
			{
				_context.Add(personEntity);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				return false;
				
			}
			return true;
		}

		public bool Delete(int id)
		{
			try
			{
				_context.Persons.Remove(_context.Persons.Find(id));
			}
			catch (Exception)
			{

				return false;
			}
			return true;
		}
		public bool Update()
		{
			try
			{
				_context.Persons.Remove(_context.Persons.Find(id))///
			}
			catch (Exception)
			{

				return false;
			}
			return true;
		}

		public IEnumerable<PersonEntity> GetAll()
		{
			try
			{
				return _context.Persons.Where(x => x.isDeleted==false).ToList();
			}
			catch (Exception)
			{

				throw;
			}
			
		}

		public PersonEntity GetById<TUniqueId>(TUniqueId id)
		{
			try
			{
				return _context.Find<int>()
			}
			catch (Exception)
			{

				throw;
			}
		}


		public PersonEntity GetByName(string name)
		{
			try
			{
				return	_context.Find<PersonEntity>(name);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
