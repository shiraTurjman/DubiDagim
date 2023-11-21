using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IImageRepository
    {
        Task<int> AddImageAsync(IFormFile imageData);
        Task<byte[]> GetImageByImgIdAsync(int imgId);
        Task<byte[]> GetImageByItemIdAsync(int itemId);
        Task DeleteImageByItemIdAsync(int itemId);
    }
}
