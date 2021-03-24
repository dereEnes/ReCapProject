using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Core.CrossCuttingConcerns.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Entities.DTOs;
using Core.Utilities.Business;
using Core.Aspects.Autofact.Transection;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private ICustomerDal _customerDal;
        private IRentalDal _RentalDal;
        public RentalManager(IRentalDal rentalDal, ICustomerDal customerDal)
        {
            _RentalDal = rentalDal;
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {


            //IResult result = BusinessRules.Run(
            //    CheckForCarIsAvailable(rental.CarId)
            //    );

                _RentalDal.Add(rental);
                return new SuccessResult(Messages.RentAdded);

         //   CheckForCustomerExist(rental.CustomerId),
            
        }
        private IResult CheckForCarIsAvailable( int carId)
        {
            
            if (_RentalDal.Get(r => r.CarId == carId && r.ReturnDate == null) != null){
                return new ErrorResult(Messages.carIsNotAvailable);
            }
            var lastEntry = _RentalDal.CheckForAvailable(r=>r.CarId==carId);
            return new SuccessResult();

            }
        private IResult CheckForCustomerExist(int customerId)
        {
            var customer = _customerDal.Get(c => c.UserId == customerId);
            if (customer == null)
            {
                return new ErrorResult(Messages.CustomerDidntFound);
            }
            return new SuccessResult();
        }

        public IResult CheckForRent(int carId)
        {
            IResult result = BusinessRules.Run(
                CheckForCarIsAvailable(carId)
                );
            return result;

        }

        public IResult Delete(Rental rental)
        {
            _RentalDal.Delete(rental);
            return new SuccessResult(Messages.RentDeleted);
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_RentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_RentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_RentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _RentalDal.Update(rental);
            return new SuccessResult(Messages.RentUpdated);
        }

        [TransactionScopeAspect]
        public IResult TransSectionRent(Rental rental)
        {
            _RentalDal.Add(rental);
            return new SuccessResult(Messages.RentAdded);
        }

        public IResult Payment(Payment payment)
        {
            return new SuccessResult(Messages.SuccessfulPayment);
        }
    }
}
