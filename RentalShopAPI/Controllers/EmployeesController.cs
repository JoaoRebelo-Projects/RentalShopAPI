using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalShopService.Domain.Employee;
using RentalShopService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAll()
        {
            var employees = await _employeeService.GetAll();
            return Ok(employees);
        }
    }
}
