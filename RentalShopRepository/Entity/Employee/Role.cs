using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Role: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int EmployeePermissionId { get; set; }
        public int ProductPermissionId { get; set; }
        public int MemberPermissionId { get; set; }
        public int ProductAssignmentPermissionId { get; set; }

        [ForeignKey("EmployeePermissionId")]
        public virtual PermissionLevel EmployeePermission { get; set; }

        [ForeignKey("ProductPermissionId")]
        public virtual PermissionLevel ProductPermission { get; set; }

        [ForeignKey("MemberPermissionId")]
        public virtual PermissionLevel MemberPermission { get; set; }

        [ForeignKey("ProductAssignmentPermissionId")]
        public virtual PermissionLevel ProductAssignmentPermission { get; set; }

        #region Foreign Entities

        public virtual ICollection<Employee> Employees { get; set; }

        #endregion
    }
}
