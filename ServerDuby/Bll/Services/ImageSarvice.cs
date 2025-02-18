using Bll.Interfaces;
using Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Services
{
    public class ImageSarvice :IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageSarvice(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<int> AddImageAsync(IFormFile imageData, int itemId)
        {
           return await _imageRepository.AddImageAsync(imageData, itemId);
        }

        public async Task DeleteImageByItemIdAsync(int itemId)
        {
            await _imageRepository.DeleteImageByItemIdAsync(itemId);
        }

        public async Task<byte[]> GetImageByImgIdAsync(int imgId)
        {
            return await _imageRepository.GetImageByImgIdAsync(imgId);
        }

        public async Task<List<byte[]>> GetImageByItemIdAsync(int itemId)
        {
            return await _imageRepository.GetImageByItemIdAsync(itemId);
        }

        public async Task<byte[]> GetFirstImageByItemIdAsync(int itemId)
        {
            return await _imageRepository.GetFirstImageByItemIdAsync(itemId);
        }
    }
}
