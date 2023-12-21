using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IImageService
    {
        Task<int> AddImageAsync(IFormFile imageData, int itemId);
        Task<byte[]> GetImageByImgIdAsync(int imgId);
        Task<List<byte[]>> GetImageByItemIdAsync(int itemId);
        Task DeleteImageByItemIdAsync(int itemId);
    }
}
