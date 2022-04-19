using AutoMapper;

using WebApp.Controllers.Models;
using WebApp.Models;


namespace WebApp.Mapper
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<PersonDTO, PersonEntity>();
           
        }
    }
}
