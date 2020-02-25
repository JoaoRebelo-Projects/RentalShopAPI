using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Membership: BaseEntity
    {
        [Required]
        public string Description { get; set; }

        public decimal MonthlySubscriptionValue { get; set; }

        public int MaxReservedProducts { get; set; }

        public int MaxReservedDays { get; set; }

        #region Foreign Entities

        public virtual ICollection<Member> Members { get; set; }

        #endregion
    }
}
