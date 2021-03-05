using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
