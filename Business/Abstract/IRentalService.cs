using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int RentalId);
        IDataResult<List<Rental>> GetAll();
        IResult CheckForRent(int carId);
        IDataResult<List<RentalDetailsDto>> GetRentalDetailsDto();
        IResult TransSectionRent(Rental rental);
        IResult Payment(Payment payment);

    }
}
