using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AddCarModel
    {
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
