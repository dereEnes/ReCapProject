using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter.Findex
{
    class FindexManager : IFindexService
    {
        public int Calculate(CreditCard creditCard)
        {
            return 1500;
        }
    }
}
