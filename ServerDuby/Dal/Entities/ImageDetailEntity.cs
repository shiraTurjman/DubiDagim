using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class ImageDetailEntity
    {
        [Key]
        [Required]
        public int ImgId { get; set; }

        [Required]
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public ItemEntity Item { get; set; }

        [Required]
        public string FileName { get; set; }
       
        [Required]
        public byte[] FileData { get; set; } 

    }
}
