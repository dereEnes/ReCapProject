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

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _RentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _RentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(),rental);

            var lastEntry = _RentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate==null);
            if (lastEntry==null)
            {
                _RentalDal.Add(rental);
                return new SuccessResult(Messages.RentAdded);
                
                
            }
            return new ErrorResult(Messages.RentFailed);
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
    }
}
