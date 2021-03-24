using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard, bool>> filter = null);
        IResult Add(CreditCard creditCard);
    }
}
