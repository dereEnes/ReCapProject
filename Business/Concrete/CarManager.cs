using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Caching;
using Core.Aspects.Autofact.Performance;
using Core.Aspects.Autofact.Transection;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal productDal)
        {
            _carDal = productDal;
        }
        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICarService.Get")]//içinde bu olanları kaldırır
        //[SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        //[SecuredOperation("admin,car.delete")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        //[SecuredOperation("admin,car.update")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id),Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==id));
        }

        
        public IDataResult<List<CarDetailsDto>> GetCarDetailsDtos(Expression<Func<Car, bool>> filter = null)
        {
            if (filter!=null)
            {
                return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(filter));
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());

        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter));
        }
    }
}
