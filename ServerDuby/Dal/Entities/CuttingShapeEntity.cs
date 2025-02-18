using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dal.Entity
{
    public class CuttingShapeEntity
    {
        [Key]
        [Required]
        public int CuttingShapeId { get; set; }

        [Required]
        public string ShapeEnName { get; set; }

        [Required] 
        public string ShapeHeName { get;set; }

        [Required]
        public string Details { get; set; } 
    }
}
