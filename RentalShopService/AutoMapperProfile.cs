using AutoMapper;
using RentalShopRepository.Entity;
using RentalShopService.Domain.Employee;

namespace RentalShopService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
