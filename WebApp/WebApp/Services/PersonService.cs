using AutoMapper;

using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
	public class PersonService : IPersonsService
	{

		private readonly IPersonsRepository _personsRepository;
		private readonly IMapper _mapper;

		public PersonService(IPersonsRepository personsRepository,
								IMapper mapper)
		{
			_personsRepository =personsRepository;
			_mapper = mapper;
		}

		public bool Create(PersonEntity item)
		{
			var person = new PersonEntity
			{
				Name = item.Name,
				Id = item.Id,
				isDeleted = false
							
			};
			return _personsRepository.Add(person);
		}

		public bool Delete(int id)
		{
			return _personsRepository.Delete(id);
		}

		public PersonEntity GetById()
		{
			throw new NotImplementedException();
		}


		public IList<PersonEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public bool Update(PersonEntity item)
		{
			throw new NotImplementedException();
		}
	}
}
