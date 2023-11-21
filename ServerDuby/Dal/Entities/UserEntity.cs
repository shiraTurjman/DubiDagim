using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class UserEntity
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        public string Password { get; set; } 

        [Required]
        public int CityId { get; set; }
        public CityEntity City { get; set; }

        [Required]
        public string Address { get; set; } 

        [Required]
        public string Phone { get; set; } 

    }
}
