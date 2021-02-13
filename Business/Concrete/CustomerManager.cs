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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private int hour = 03;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Customer>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), CustomerMessages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Customer>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), CustomerMessages.CustomersListed); ;
        }

        public IResult AddService(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(CustomerMessages.CustomerAdded);
        }

        public IResult UpdateService(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(CustomerMessages.CustomerUpdated);
        }

        public IResult DeleteService(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(CustomerMessages.CustomerDeleted);
        }
    }
}
