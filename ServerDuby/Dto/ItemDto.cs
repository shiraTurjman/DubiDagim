
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dto
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string ItemEnName { get; set; }

        public string ItemHeName { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Details { get; set; }

        public double AverageSize { get; set; }

        public byte[] ? Images { get; set; }
      
    }
}
