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
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=100,Description="Renault Clio"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2016,DailyPrice=150,Description="Renault Megane"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2017,DailyPrice=200,Description="Ford Mustang"},
                new Car{Id=4,BrandId=2,ColorId=3,ModelYear=2018,DailyPrice=120,Description="Ford"},
                new Car{Id=5,BrandId=3,ColorId=4,ModelYear=2020,DailyPrice=75,Description="Fiat Egea"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int[] id)
        {
            List<Car> carToID = new List<Car>();
            for (int i = 0; i < id.Length; i++)
            {
                foreach (var c in _cars)
                {
                    if (id[i] == c.Id)
                    {
                        carToID.Add(c);
                    }
                }
            }
            return carToID.ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
