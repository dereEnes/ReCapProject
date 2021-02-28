using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var path = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);
            }

            var carimage = new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };

            var result = _carImageService.Add(carimage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /*
        [HttpPost("add")]
        
        public IActionResult Add([FromForm] CarImage carImages)
        {
            try
            {
                if (carImages.ImagePath.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\CarImages\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    
                        using (FileStream fileStream=System.IO.File.Create(path+carImages.ImagePath.FileName))
                        {
                        carImages.ImagePath.CopyTo(fileStream);
                        fileStream.Flush();
                        _carImageService.Add(carImages);
                        return Ok();
                        }
                    
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                BadRequest();
            }
            return Ok();
        }
        */
    }
}
