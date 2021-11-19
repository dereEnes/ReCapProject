using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Collection
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CardNo { get; set; }
        public int CvCode { get; set; }
        public int ExpityMonth { get; set; }
        public int ExpityYear { get; set; }
        public int Amount { get; set; }
        public string CustomerEmail { get; set; }
    }
}
