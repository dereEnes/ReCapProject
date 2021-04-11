using Business.Abstract;
using Business.Adapter.Findex;
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
        private IFindexService _findexService;
        private ICreditCardService _creditCardService;
        public PaymentManager(IPaymentDal paymentDal, IFindexService findexService)
        {
            _paymentDal = paymentDal;
            _findexService = findexService;
        }

        //[TransactionScopeAspect]
        public IResult Add(Collection collection)
        {
            CreditCard creditCard = new CreditCard
            {
                CardNo = collection.CardNo,
                CvCode = collection.CvCode,
                ExpityMonth = collection.ExpityMonth,
                ExpityYear = collection.ExpityYear
                
            };
            _creditCardService.Add(creditCard);

            //Payment payment = new Payment { }
            //_paymentDal.Add();
            //// _rentalDal.Add();
            return new SuccessResult(Messages.SuccessfulPayment);

        }

        public IResult Delete(Collection creditCard)
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

        public IResult Update(Collection creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
