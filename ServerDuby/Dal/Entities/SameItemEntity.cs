using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class SameItemEntity
    {
        [Key]
        [Required]
        public int SameItemId { get; set; }

        [ForeignKey("Items")]
        public int? ItemAId { get; set; }
        public ItemEntity? ItemA { get; set; }

       
        [ForeignKey("Items")]
        public int? ItemBId { get; set; }
        public ItemEntity? ItemB { get; set;}

    }
}
