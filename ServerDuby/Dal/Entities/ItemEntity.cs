using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entity
{
    public class ItemEntity
    {
        [Key]
        [Required]
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; } 

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public string Details { get; set; }

        [Required]
        public double AverageSize { get; set; }

    }
}
