using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dto
{
    public class AddItemDto
    {
        public int? ItemId { get; set; }

        public string ItemEnName { get; set; }

        public string ItemHeName { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public string Details { get; set; }

        public double AverageSize { get; set; }
    }
}
