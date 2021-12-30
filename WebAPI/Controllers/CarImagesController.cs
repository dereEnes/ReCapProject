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
        public class FileUploadAPI
        {

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            foreach (var item in result.Data)
            {
                item.ImagePath = item.ImagePath.Replace('\\','/');
            }
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);

            foreach (var item in result.Data)
            {

                item.ImagePath = item.ImagePath.Replace("\\", "/");
            }
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
        public IActionResult Add([FromForm(Name = ("CarImage"))] IFormFile objectFile, [FromForm] int id)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(objectFile.FileName);


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                objectFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            if (objectFile == null)
            {
                //carImage.ImagePath =  "default.png";
            }
            var result = _carImageService.Add(new CarImage
            {
                CarId = id,
                Date = DateTime.Now,
                ImagePath = newGuidPath
            });
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
