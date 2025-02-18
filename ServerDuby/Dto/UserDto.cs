using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class UserDto
    {
      public int? userId { get; set; }
      public string userName { get; set; }
      public string email { get; set; }
      public string password { get; set; }
      public int? cityId { get; set; }
      public string? address { get; set; }
      public string phone { get; set; }
        // agree?:boolean;

    }
}
