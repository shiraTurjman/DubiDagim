using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dal.Entity
{
    public class CityEntity
    {
        [Key]
        [Required]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
