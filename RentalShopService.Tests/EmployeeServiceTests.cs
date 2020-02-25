using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using RentalShopRepository.Context;
using RentalShopRepository.Entity;
using RentalShopRepository.Entity.UnitofWork;
using RentalShopService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RentalShopService.Tests
{
    public class EmployeeServiceTests
    {
        protected Mock<IUnitOfWork> _unitOfWorkMock;
        protected IEmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            var employees = new List<Employee>() {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(1991, 04, 10),
                    Email = "JohnDoe@email.com",
                    Phone = "123456789",
                    RoleId = 1,
                    CreatedAt = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mitchell Connor",
                    FirstName = "Mitchell",
                    LastName = "Connor",
                    BirthDate = new DateTime(1992, 07, 11),
                    Email = "MitchellConnor@email.com",
                    Phone = "987654321",
                    RoleId = 2,
                    CreatedAt = DateTime.Now
                }
            };

            _unitOfWorkMock.Setup(x => x.GetRepositoryAsync<Employee>().GetAll()).ReturnsAsync(employees);

            var profile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

            _employeeService = new EmployeeService(_unitOfWorkMock.Object, new Mapper(configuration));
        }

        [Fact]
        public async void GetAllTest()
        {
            var employees = await _employeeService.GetAll().ConfigureAwait(false);

            Assert.Equal(2, employees.Count());
        }
    }
}
