using System;

using AutoMapper;

using WebApp.Controllers.DataTransfer;
using WebApp.Entities;

namespace WebApp.Mapper
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<PersonEntity, PersonDTO>();
		}
	}
}
