using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _BrandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _BrandDal = brandDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckIfBrandNameAlreadyExist(brand));
            if (result != null)
            {
                return result;
            }

            _BrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
        
        public IResult Delete(int id)
        {
            _BrandDal.Delete(GetByBrandId(id).Data);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [ValidationAspect(typeof(UpdateBrandValidator))]
        public IResult Update(UpdateBrandModel brand)
        {
            var mappedBrand = _mapper.Map<Brand>(brand);
            _BrandDal.Update(mappedBrand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_BrandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_BrandDal.Get(b => b.Id == brandId), Messages.BrandListed);
        }
        public IResult CheckIfBrandNameAlreadyExist(Brand brand)
        {
            var result = _BrandDal.GetAll(p => p.Name == brand.Name).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}
