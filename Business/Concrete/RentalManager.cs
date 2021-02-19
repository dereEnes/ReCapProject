﻿using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _RentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _RentalDal = rentalDal;
        }
        
        public IResult Add(Rental rental)
        {
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

        public IResult Update(Rental rental)
        {
            _RentalDal.Update(rental);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}