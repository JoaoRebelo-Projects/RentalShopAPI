using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Image: BaseEntity
    {
        [Required]
        public string FilePath { get; set; }

        public int FolderId { get; set; }

        [ForeignKey("FolderId")]
        public virtual ImageFolder ImageFolder { get; set; }

        #region Foreign Entities

        public virtual Employee EmployeePhoto { get; set; }

        public virtual ProductType ProductTypeIcon { get; set; }

        public virtual Product ProductImage { get; set; }

        #endregion
    }
}
