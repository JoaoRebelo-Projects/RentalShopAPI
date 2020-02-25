using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalShopRepository.Entity
{
    public class Login: BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; } //Encoded

        [NotMapped]
        public string DecryptedPassword
        {
            get { return Password; } // Add Decryption
            set { Password = value; } // Add Encryption
        }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
    }
}
