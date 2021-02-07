using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, Descriptions = "BMW" },
            new Car { CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 200, Descriptions = "AUDI" },
            new Car { CarId = 3, BrandId = 1, ColorId = 2, DailyPrice = 300, Descriptions = "MERCEDES" }

           };

        }
        public void Add(Car car)
        {

            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            //LINQ
            
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //LINQ
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
