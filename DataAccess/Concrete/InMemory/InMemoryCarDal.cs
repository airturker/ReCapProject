﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, Description = "BMW" },
            new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "AUDI" },
            new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 300, Description = "MERCEDES" }

           };

        }
        public void Add(Car car)
        {

            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            //LINQ
            
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            //LINQ
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
