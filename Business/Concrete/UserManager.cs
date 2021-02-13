﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private int hour = 03;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<User>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), UserMessages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<User>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), UserMessages.UserListed);
        }

        public IResult AddService(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult UpdateService(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(UserMessages.UserUpdated);
        }

        public IResult DeleteService(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(UserMessages.UserDeleted);
        }
    }
}