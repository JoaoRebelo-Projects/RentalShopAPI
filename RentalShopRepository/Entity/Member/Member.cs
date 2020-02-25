using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Member: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MembershipId { get; set; }
        [ForeignKey("MembershipId")]
        public virtual Membership Membership { get; set; }

        #region Foreign Entities

        public virtual ICollection<ProductAssignment> ProductAssignments { get; set; }

        #endregion
    }
}
