using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter.Findex
{
    public interface IFindexService
    {
        int Calculate(CreditCard creditCard);
    }
}
