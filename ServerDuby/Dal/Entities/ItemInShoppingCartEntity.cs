using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class ItemInShoppingCartEntity
    {
        [Key]
        [Required]
        public int ItemInShoppingCartId { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public ItemEntity Item { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [ForeignKey("CuttingShapes")]
        public int CuttingShapeId { get; set; }
        public CuttingShapeEntity CuttingShape { get; set; }
        public string Details { get; set; }

        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; } = -1;
        public OrderEntity Order { get; set; }

    }
}
