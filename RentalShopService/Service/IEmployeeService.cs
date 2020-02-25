using RentalShopService.Domain.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopService.Service
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetAll();
    }
}
