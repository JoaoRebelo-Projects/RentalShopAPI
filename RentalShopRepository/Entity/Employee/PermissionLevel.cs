using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class PermissionLevel: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        #region Foreign Entities

        public virtual ICollection<Role> EmployeePermissionRoles { get; set; }
        public virtual ICollection<Role> ProductPermissionRoles { get; set; }
        public virtual ICollection<Role> ProductAssignmentPermissionRoles { get; set; }
        public virtual ICollection<Role> MemberPermissionRoles { get; set; }

        #endregion
    }
}
