﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetRentalDetails();
         Rental CheckForAvailable(Expression<Func<Rental, bool>> filter);
    }
}
