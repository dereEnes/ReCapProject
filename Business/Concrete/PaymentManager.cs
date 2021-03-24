using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Transection;
using Core.Aspects.Autofact.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private IRentalDal _rentalDal;
        private ICreditCardService _creditCardService;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        //[TransactionScopeAspect]
        public IResult Add(CreditCard payment)
        {
            _creditCardService.Add(payment);

            // _rentalDal.Add();
            return new SuccessResult(Messages.SuccessfulPayment);

        }

        public IResult Delete(CreditCard payment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Payment> Get(Expression<Func<Payment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetAll(Expression<Func<Payment, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CreditCard payment)
        {
            throw new NotImplementedException();
        }
    }
}
