using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Employee: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public int RoleId { get; set; }
        public int? PhotoId { get; set; }
        public int? HierarchialSuperiorId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("PhotoId")]
        public virtual Image Photo { get; set; }

        [ForeignKey("HierarchialSuperiorId")]
        public virtual Employee HierarchialSuperior { get; set; }

        #region Foreign Entities

        public virtual ICollection<Employee> HierarchialSubordinates { get; set; }

        public virtual Login Login { get; set; } 

        #endregion


    }
}
