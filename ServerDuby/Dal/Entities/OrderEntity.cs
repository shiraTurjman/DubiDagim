﻿using System;
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
        
        public DateTime? OrderDate { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public bool IsShoppingCart { get; set; }

    }
}
