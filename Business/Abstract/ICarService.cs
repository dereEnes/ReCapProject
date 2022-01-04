using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IResult Add(AddCarModel model);
       // IResult Delete(Car car);
        IResult Delete(int id);
        IResult Update(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetailsDtos(Expression<Func<Car, bool>> filter = null);
        IResult AddTransactionalTest(Car car);
    }
}
