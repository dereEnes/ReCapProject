﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _UserDal;
        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            ValidationTool.Validate(new UserValidator(),user);
            _UserDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result =_UserDal.Get(u=>u.Email==email);
            if (result==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_UserDal.GetClaims(user));
        }
        /*
public IResult Delete(User user)
{
   _UserDal.Delete(user);
   return new SuccessResult(Messages.UserDeleted);
}

public IDataResult<List<User>> GetAll()
{
   return new SuccessDataResult<List<User>>(_UserDal.GetAll());
}

public IDataResult<User> GetById(int userId)
{
   return new SuccessDataResult<User>(_UserDal.Get(u=>u.Id==userId));
}

public IResult Update(User user)
{
   _UserDal.Update(user);
   return new SuccessResult(Messages.UserUpdated);
}*/
    }
}
