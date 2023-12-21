using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dto
{
    public class LoginDto
    {
        [EmailAddress]
        [MaxLength(75)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [MinLength(5)]
        [Required]
        public string Password { get; set; }
    }
}
