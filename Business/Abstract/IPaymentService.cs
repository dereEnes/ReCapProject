using Core.DataAccess;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
         IResult Add(CreditCard payment);


        IResult Delete(CreditCard payment);
        

         IDataResult<Payment> Get(Expression<Func<Payment, bool>> filter);
        

        IDataResult<List<Payment>> GetAll(Expression<Func<Payment, bool>> filter = null);


        IResult Update(CreditCard payment);
        
    }
}
