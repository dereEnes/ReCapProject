using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _ProductDal;
        public CarManager(ICarDal productDal)
        {
            _ProductDal = productDal;
        }
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _ProductDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _ProductDal.Delete(car);
            return new SuccessResult();
        }
        public IResult Update(Car car)
        {
            _ProductDal.Update(car);
            return new SuccessResult();
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _ProductDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _ProductDal.GetAll(p=>p.BrandId==id),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _ProductDal.GetAll(p=>p.ColorId==id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsDtos()
        {
            return new SuccessDataResult<List<CarDetailsDto>>( _ProductDal.GetCarDetails());
        }
    }
}
