﻿using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailsDto>> getCustomerDetailsDto();

    }
}
