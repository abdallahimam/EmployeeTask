using AutoMapper;
using EmployeeTask.Dtos;
using EmployeeTask.Models;

namespace EmployeeTask.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
