using Bll.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        //Add item 

        [HttpPost("AddImage/{itemId}")]
        public async Task<ActionResult<int>> AddImage([FromForm] IFormFile file,int itemId)
        {
            string name = file.FileName;
            string extension = Path.GetExtension(file.FileName);
            //read the file
            //using (var memoryStream = new MemoryStream())
            //{
            //    file.CopyTo(memoryStream);
            //}
            if (file == null)
            {
                return BadRequest();
            }

            try
            {
                return await _imageService.AddImageAsync(file,itemId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet("GetImageById/{id}")]
        public async Task<ActionResult<byte[]>> GetImageById(int id)
        {
            try
            {
                var imageData = await _imageService.GetImageByImgIdAsync(id);
                return imageData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("GetImageByItemId/{itemId}")]
        public async Task<ActionResult<List<byte[]>>> GetImageByItemId(int itemId)
        {
            try
            {
                return await _imageService.GetImageByItemIdAsync(itemId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("deleteImageByItemId/{id}")]
        public async Task<ActionResult> DeleteImageByItem(int id) 
        {
            try
            {
                await _imageService.DeleteImageByItemIdAsync(id);
                return Ok(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
