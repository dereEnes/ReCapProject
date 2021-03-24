using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public string CardNo { get; set; }
        public int ExpityMonth { get; set; }
        public int ExpityYear { get; set; }
        public int CvCode { get; set; }
    }
}
