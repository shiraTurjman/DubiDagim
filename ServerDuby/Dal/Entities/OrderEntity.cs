using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class OrderEntity
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

    }
}
