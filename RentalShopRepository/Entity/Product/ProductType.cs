using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class ProductType: BaseEntity
    {
        [Required]
        public string Description { get; set; }

        public int? IconId { get; set; }

        [ForeignKey("IconId")]
        public virtual Image Image { get; set; }

        #region Foreign Entities

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
