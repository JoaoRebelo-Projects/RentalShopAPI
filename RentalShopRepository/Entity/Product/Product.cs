using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Product: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int TypeId { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("TypeId")]
        public virtual ProductType ProductType { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        #region Foreign Entities

        public virtual ICollection<ProductAssignment> Assignments { get; set; }

        #endregion

    }
}
