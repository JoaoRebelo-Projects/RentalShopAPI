using AutoMapper;
using RentalShopRepository.Entity;
using RentalShopRepository.Entity.UnitofWork;
using RentalShopService.Domain.Employee;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopService.Service
{

    public class EmployeeService: IEmployeeService
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        public virtual async Task<List<EmployeeDTO>> GetAll()
        {
            var employees = await _unitOfWork.GetRepositoryAsync<Employee>().GetAll();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

    }

}
