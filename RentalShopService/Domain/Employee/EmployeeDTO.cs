using System;
using System.Collections.Generic;
using System.Text;

namespace RentalShopService.Domain.Employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public int RoleId { get; set; }
        public int? PhotoId { get; set; }
        public int? HierarchialSuperiorId { get; set; }

        /*public Role Role { get; set; }

        public Image Photo { get; set; }

        public Employee HierarchialSuperior { get; set; }

        #region Foreign Entities

        public ICollection<Employee> HierarchialSubordinates { get; set; }

        public Login Login { get; set; }

        #endregion

    */
    }
}
