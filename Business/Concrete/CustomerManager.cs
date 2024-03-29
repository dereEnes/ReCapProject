﻿using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofact.Validation;
using Business.BusinessAspects.Autofac;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
       // [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _CustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_CustomerDal.Get(c=>c.UserId==customerId));
        }

        public IDataResult<List<CustomerDetailsDto>> getCustomerDetailsDto()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_CustomerDal.GetCustomerDetailsDto());
        }

        public IResult Update(Customer customer)
        {
            _CustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
