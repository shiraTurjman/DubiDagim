using Dal.Entity;
using Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDbContextFactory<ServerDbContext> _factory;

        public ImageRepository(IDbContextFactory<ServerDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<int> AddImageAsync(IFormFile imageData, int itemId)
        {
            using var context = _factory.CreateDbContext();
            try
            {
                var ImageDetails = new ImageDetailEntity()
                {
                    ImgId = 0,
                    FileName = imageData.FileName,
                    ItemId = itemId,
                };

                using (var stream = new MemoryStream())
                {
                    imageData.CopyTo(stream);
                    ImageDetails.FileData = stream.ToArray();
                }

                var result = context.ImageDetails.Add(ImageDetails);
                await context.SaveChangesAsync();
                context.ImageDetails.Entry(ImageDetails).GetDatabaseValues();
                int id = ImageDetails.ImgId;
                return id;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteImageByItemIdAsync(int itemId)
        {
            using var context = _factory.CreateDbContext();
            var list = await context.ImageDetails.Where(i => i.ItemId == itemId).ToListAsync();
            if (list != null)
            {
               
                foreach (var item in list)
                {
                    context.ImageDetails.Remove(item);
                }
                await context.SaveChangesAsync();
                
            }
            else
            {
                throw new Exception("could not delete image");
            }
        }

        Task<byte[]> IImageRepository.GetImageByImgIdAsync(int imgId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<byte[]>> GetImageByItemIdAsync(int itemId)
        {
            using var context = _factory.CreateDbContext();
            var list = await context.ImageDetails.Where(i => i.ItemId == itemId).ToListAsync();
            if (list != null)
            {
                var result = new List<byte[]>();
                foreach (var item in list)
                {
                    result.Add(item.FileData);
                }
                return result;
            }
            else
            {
                throw new Exception("could not get image by item id");
            }

         
        }
    }
}
