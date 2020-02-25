using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class ImageFolder: BaseEntity
    {
        [Required]
        public string FolderName { get; set; }

        [Required]
        public string FolderPath { get; set; }

        #region Foreign Entities

        public virtual ICollection<Image> Images { get; set; }

        #endregion
    }
}
