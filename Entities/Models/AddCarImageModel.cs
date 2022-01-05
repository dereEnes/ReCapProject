using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AddCarImageModel
    {
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
