﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private int hour = 03;
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAllService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<Car>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<Car>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), CarMessages.CarsListed);

        }

        public IResult AddService(Car entity)
        {

            if (entity.Descriptions.Length <= 10 || entity.DailyPrice < 0)
            {
                return new ErrorResult(CarMessages.CarAddError);
            }
            _carDal.Add(entity);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult UpdateService(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(CarMessages.CarUpdated);
        }

        public IResult DeleteService(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(CarMessages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsService()
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<List<CarDetailDto>>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), CarMessages.CarsListed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsByIdService(int id)
        {
            if (DateTime.Now.Hour == hour)
            {
                return new ErrorDataResult<CarDetailDto>(GeneralMessages.Maintenance);
            }
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.CarId == id), CarMessages.CarsListed);
        }
    }
}
