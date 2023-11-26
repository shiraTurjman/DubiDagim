 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entity
{
    public class CuttingShapePerItemEntity
    {
        [Key]
        [Required] 
        public int CuttingShapePerItemId { get; set; }

        [Required]
        [ForeignKey("CuttingShapes")]
        public int CuttingShapeId { get; set; }
        public CuttingShapeEntity CuttingShape { get; set; }

        [Required]
        [ForeignKey("Items")]
        public int ItemId { get; set; }

        public ItemEntity Item { get; set; }    
        
    }
}
