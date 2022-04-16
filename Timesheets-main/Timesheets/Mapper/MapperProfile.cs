using AutoMapper;
using Timesheets.Controllers.Models;
using Timesheets.DAL.Entities;

namespace Timesheets.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerDto, CustomerEntity>();
            CreateMap<ContractDto, ContractEntity>();
            CreateMap<InvoiceDto, InvoiceEntity>();
            CreateMap<TaskDto, TaskEntity>();
            CreateMap<EmployeeDto, EmployeeEntity>();
        }
    }
}