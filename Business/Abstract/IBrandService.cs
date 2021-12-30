using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetByBrandId(int brandId);
        
        IResult Add(Brand brand);
        IResult Delete(int id);
        IResult Update(UpdateBrandModel brand);
    }
}
